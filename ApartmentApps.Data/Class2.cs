using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ApartmentApps.Data
{
    public class Filter
    {
        public string PropertyName { get; set; }
        public string Value { get; set; }
        public ExpressionOperator Operator { get; set; } = ExpressionOperator.Contains;
    }

    public class FilterPath : Attribute
    {
        public FilterPath(string path)
        {
            Path = path;
        }

        public string Path { get; set; }
    }
    public enum ExpressionOperator
    {
        Contains,
        GreaterThan,
        GreaterThanOrEqual,
        LessThan,
        LessThanOrEqualTo,
        StartsWith,
        EndsWith,
        Equals,
        NotEqual
    }

    public static class ExpressionBuilder
    {
        // Define some of our default filtering options
        private static MethodInfo containsMethod = typeof(string).GetMethod("Contains", new[] { typeof(string) });
        private static MethodInfo startsWithMethod = typeof(string).GetMethod("StartsWith", new[] { typeof(string) });
        private static MethodInfo endsWithMethod = typeof(string).GetMethod("EndsWith", new[] { typeof(string) });

        public static Expression<Func<T, bool>> GetExpression<T>(List<Filter> filters)
        {
            // No filters passed in #KickIT
            if (filters.Count == 0)
                return Expression.Lambda<Func<T,bool>>(Expression.Constant(true), Expression.Parameter(typeof(T), "parm"));

            // Create the parameter for the ObjectType (typically the 'x' in your expression (x => 'x')
            // The "parm" string is used strictly for debugging purposes
            ParameterExpression param = Expression.Parameter(typeof(T), "parm");

            // Store the result of a calculated Expression
            Expression exp = null;

            if (filters.Count == 1)
                exp = GetExpression<T>(param, filters[0]); // Create expression from a single instance
            else if (filters.Count == 2)
                exp = GetExpression<T>(param, filters[0], filters[1]); // Create expression that utilizes AndAlso mentality
            else
            {
                // Loop through filters until we have created an expression for each
                while (filters.Count > 0)
                {
                    // Grab initial filters remaining in our List
                    var f1 = filters[0];
                    var f2 = filters[1];

                    // Check if we have already set our Expression
                    if (exp == null)
                        exp = GetExpression<T>(param, filters[0], filters[1]); // First iteration through our filters
                    else
                        exp = Expression.AndAlso(exp, GetExpression<T>(param, filters[0], filters[1])); // Add to our existing expression

                    filters.Remove(f1);
                    filters.Remove(f2);

                    // Odd number, handle this seperately
                    if (filters.Count == 1)
                    {
                        // Pass in our existing expression and our newly created expression from our last remaining filter
                        exp = Expression.AndAlso(exp, GetExpression<T>(param, filters[0]));

                        // Remove filter to break out of while loop
                        filters.RemoveAt(0);
                    }
                }
            }
            
            return Expression.Lambda<Func<T, bool>>(exp, param);
        }

        private static Expression GetExpression<T>(ParameterExpression param, Filter filter)
        {
            var members = filter.PropertyName.Split('.');

            MemberExpression member = Expression.Property(param, members[0]);
            // The member you want to evaluate (x => x.FirstName)
            foreach (var item in members.Skip(1))
            {
                member = Expression.Property(member, item);
            }
           
    
            // The value you want to evaluate
            ConstantExpression constant = Expression.Constant(filter.Value.ToLower());


            // Determine how we want to apply the expression
            switch (filter.Operator)
            {
                case ExpressionOperator.Equals:
                    return Expression.Equal(Expression.Call(member, typeof(string).GetMethods().First(p=>p.Name == "ToLower")), constant);

                case ExpressionOperator.Contains:
                    return Expression.Call(Expression.Call(member, typeof(string).GetMethods().First(p => p.Name == "ToLower")), containsMethod, constant);

                case ExpressionOperator.GreaterThan:
                    return Expression.GreaterThan(member, constant);

                case ExpressionOperator.GreaterThanOrEqual:
                    return Expression.GreaterThanOrEqual(member, constant);

                case ExpressionOperator.LessThan:
                    return Expression.LessThan(member, constant);

                case ExpressionOperator.LessThanOrEqualTo:
                    return Expression.LessThanOrEqual(member, constant);

                case ExpressionOperator.StartsWith:
                    return Expression.Call(member, startsWithMethod, constant);

                case ExpressionOperator.EndsWith:
                    return Expression.Call(member, endsWithMethod, constant);
            }

            return null;
        }

        private static BinaryExpression GetExpression<T>(ParameterExpression param, Filter filter1, Filter filter2)
        {
            Expression result1 = GetExpression<T>(param, filter1);
            Expression result2 = GetExpression<T>(param, filter2);
            return Expression.AndAlso(result1, result2);
        }
        public static IQueryable<TEntity> OrderBy<TEntity>(this IQueryable<TEntity> source, string orderByProperty,
                          bool desc)
        {
            string command = desc ? "OrderByDescending" : "OrderBy";
            var type = typeof(TEntity);
            var property = type.GetProperty(orderByProperty);
            var parameter = Expression.Parameter(type, "p");
            var propertyAccess = Expression.MakeMemberAccess(parameter, property);
            var orderByExpression = Expression.Lambda(propertyAccess, parameter);
            var resultExpression = Expression.Call(typeof(Queryable), command, new Type[] { type, property.PropertyType },
                                          source.Expression, Expression.Quote(orderByExpression));
            return source.Provider.CreateQuery<TEntity>(resultExpression);
        }

    }
}
