using PolyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MajorProject
{
    class MultiFunction : Expression
    {
        public string Name { get; }
        public List<Expression> Arguments { get; }

        public MultiFunction(string name, List<Expression> args)
        {
            Name = name;
            Arguments = args;
        }

        public override Complex Value()
        {
            // Look up implementation in a registry
            if (!MultiFunctionRegistry.TryGetValue(Name.ToLower(), out var impl))
                throw new Exception($"Unknown function '{Name}'");

            return impl(Arguments);
        }

        public override string ToString()
        {
            return $"{Name}({string.Join(", ", Arguments)})";
        }
    }

    static class MultiFunctionRegistry
    {
        public static readonly Dictionary<string, Func<List<Expression>, Complex>> Registry =
            new(StringComparer.OrdinalIgnoreCase)
            {
            { "log", args =>
                {
                    if (args.Count != 2)
                        throw new Exception("log(base, x) requires 2 arguments");

                    var b = args[0].Value();
                    var x = args[1].Value();
                    return Complex.Ln(x) / Complex.Ln(b);
                }
            },
            { "gcd", args =>
                {
                    long Gcd(long a, long b)
                    {
                        a = Math.Abs(a);
                        b = Math.Abs(b);
                        while (b != 0)
                        {
                            long t = b;
                            b = a % b;
                            a = t;
                        }
                        return a;
                    }

                    long result = (long)args[0].Value().Re;

                    for (int i = 1; i < args.Count; i++)
                        result = Gcd(result, (long)args[i].Value().Re);

                    return new Complex(result);
                }
            },
            { "lcm", args =>
                {
                    long Gcd(long a, long b)
                    {
                        a = Math.Abs(a);
                        b = Math.Abs(b);
                        while (b != 0)
                        {
                            long t = b;
                            b = a % b;
                            a = t;
                        }
                        return a;
                    }

                    long Lcm(long a, long b)
                    {
                        return Math.Abs(a * b) / Gcd(a, b);
                    }

                    long result = (long)args[0].Value().Re;

                    for (int i = 1; i < args.Count; i++)
                        result = Lcm(result, (long)args[i].Value().Re);

                    return new Complex(result);
                }
            },
            { "convert", args =>
                {
                    double value = args[0].Value().Re;

                    string fromU = args[1].Value().Re.ToString();
                    string toU   = args[2].Value().Re.ToString();

                    if (!UnitConverter.Factors.ContainsKey(fromU))
                        throw new Exception($"Unknown unit '{fromU}'");

                    if (!UnitConverter.Factors.ContainsKey(toU))
                        throw new Exception($"Unknown unit '{toU}'");

                    double baseValue = value * UnitConverter.Factors[fromU];
                    double result = baseValue / UnitConverter.Factors[toU];

                    return new Complex(result);
                }
            },
            { "sum", args =>
                {
                    double total = 0;
                    foreach (var a in args)
                        total += a.Value().Re;

                    return new Complex(total);
                }
            },
            { "prod", args =>
                {
                    double total = 1;
                    foreach (var a in args)
                        total *= a.Value().Re;

                    return new Complex(total);
                }
            },
            { "shl", args =>
                {
                    long x = (long)args[0].Value().Re;
                    int n  = (int)args[1].Value().Re;
                    return new Complex(x << n);
                }
            },
            { "shr", args =>
                {
                    long x = (long)args[0].Value().Re;
                    int n  = (int)args[1].Value().Re;
                    return new Complex(x >> n);
                }
            },
            { "mean", args =>
                {
                    double sum = 0;
                    foreach (var a in args)
                        sum += a.Value().Re;

                    return new Complex(sum / args.Count);
                }
            },
            { "median", args =>
                {
                    var list = args.Select(a => a.Value().Re).OrderBy(x => x).ToList();
                        int n = list.Count;

                        if (n % 2 == 1)
                            return new Complex(list[n / 2]);

                    return new Complex((list[n/2 - 1] + list[n/2]) / 2);
                }
            },
            { "mode", args =>
                {
                    var values = args.Select(a => a.Value().Re);

                    var mode = values
                        .GroupBy(v => v)
                        .OrderByDescending(g => g.Count())
                        .First().Key;

                    return new Complex(mode);
                }
            },
            { "fib", args =>
                {
                    int n = (int)args[0].Value().Re;

                    if (n < 0)
                        throw new Exception("fib(n) requires n ≥ 0");

                    if (n == 0) return new Complex(0);
                    if (n == 1) return new Complex(1);

                    long a = 0, b = 1;

                    for (int i = 2; i <= n; i++)
                    {
                        long temp = a + b;
                        a = b;
                        b = temp;
                    }

                    return new Complex(b);
                }
            },
            { "ncr", args =>
                {
                    if (args.Count != 2)
                        throw new Exception("nCr(n, r) requires 2 arguments");

                    var n = (int)args[0].Value().Re;
                    var r = (int)args[1].Value().Re;

                    long result = 1;
                    for (int i = 1; i <= r; i++)
                        result = result * (n - i + 1) / i;

                    return new Complex(result);
                }
            },

            { "npr", args =>
                {
                    if (args.Count != 2)
                        throw new Exception("nPr(n, r) requires 2 arguments");

                    var n = (int)args[0].Value().Re;
                    var r = (int)args[1].Value().Re;

                    long result = 1;
                    for (int i = 0; i < r; i++)
                        result *= (n - i);

                    return new Complex(result);
                }
            }

            };

        public static bool TryGetValue(string name, out Func<List<Expression>, Complex> impl)
            => Registry.TryGetValue(name, out impl);
    }


}
