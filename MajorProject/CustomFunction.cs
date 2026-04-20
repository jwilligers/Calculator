using PolyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MajorProject
{
    class CustomFunction : Expression
    {
        public string Name { get; }
        public List<Expression> Arguments { get; }
        public FunctionDefinition Definition { get; }

        public CustomFunction(string name, FunctionDefinition def, List<Expression> args)
        {
            Name = name;
            Definition = def;
            Arguments = args;

            if (args.Count != def.Parameters.Length)
                throw new Exception($"Function '{name}' expects {def.Parameters.Length} arguments, got {args.Count}");
        }

        public override Complex Value()
        {
            // Build a substitution table
            Dictionary<string, Complex> localVars = new();

            for (int i = 0; i < Definition.Parameters.Length; i++)
            {
                string param = Definition.Parameters[i];
                Complex argValue = Arguments[i].Value();
                localVars[param] = argValue;
            }

            // Evaluate the body with substituted variables
            return EvaluateWith(localVars, Definition.Body);
        }

        private Complex EvaluateWith(Dictionary<string, Complex> vars, Expression expr)
        {
            switch (expr)
            {
                case Number n:
                    return n.Value();

                case Variable v:
                    if (vars.TryGetValue(v.ToString(), out var val))
                        return val;
                    throw new Exception($"Unknown variable '{v}' in function '{Name}'");

                case Operation op:
                    return op switch
                    {
                        Addition a => EvaluateWith(vars, a.GetLeft()) + EvaluateWith(vars, a.GetRight()),
                        Subtraction s => EvaluateWith(vars, s.GetLeft()) - EvaluateWith(vars, s.GetRight()),
                        Multiplication m => EvaluateWith(vars, m.GetLeft()) * EvaluateWith(vars, m.GetRight()),
                        Division d => EvaluateWith(vars, d.GetLeft()) / EvaluateWith(vars, d.GetRight()),
                        Power p => Complex.Pow(EvaluateWith(vars, p.GetLeft()), EvaluateWith(vars, p.GetRight())),
                        _ => throw new Exception("Unknown operation")
                    };

                case UnaryFunction uf:
                    return new UnaryFunction(uf.Type, Substitute(vars, uf.Argument())).Value();

                case MultiFunction mf:
                    var newArgs = mf.Arguments.Select(a => Substitute(vars, a)).ToList();
                    return new MultiFunction(mf.Name, newArgs).Value();

                default:
                    throw new Exception("Unsupported expression type in function evaluation");
            }
        }

        private Expression Substitute(Dictionary<string, Complex> vars, Expression expr)
        {
            if (expr is Variable v && vars.ContainsKey(v.ToString()))
                return new Number(vars[v.ToString()]);

            if (expr is Operation op)
                return (Expression)Activator.CreateInstance(op.GetType(),
                    Substitute(vars, op.GetLeft()),
                    Substitute(vars, op.GetRight()));

            if (expr is UnaryFunction uf)
                return new UnaryFunction(uf.Type, Substitute(vars, uf.Argument()));

            if (expr is MultiFunction mf)
                return new MultiFunction(mf.Name, mf.Arguments.Select(a => Substitute(vars, a)).ToList());

            return expr;
        }
    }

}
