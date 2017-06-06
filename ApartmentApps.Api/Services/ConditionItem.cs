namespace ApartmentApps.Portal.Controllers
{
    public class ConditionItem
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="attrId"></param>
        /// <param name="operator">
        /// Equal | is equal to 
        /// NotEqual | is not equal to 
        /// LessThan | is less than 
        /// LessOrEqual | is less than or equal to 
        /// GreaterThan | greater than
        /// GreaterOrEqual | greater than or equal to
        /// IsNull | is null | {expr1} is null
        /// InList | is in list | {expr1} in ({expr2})
        /// StartsWith | starts with | {expr1} like {expr2}
        /// NotStartsWith | does not start with | not({ expr1}
        /// like {expr2})
        /// Contains | contains | {expr1} like {expr2}
        /// NotContains | does not contain | not({ expr1}
        /// like {expr2})
        /// Between | is between | {expr1} between {expr2} and {expr3}
        /// InSubQuery | is in set | {expr1} in ({expr2})
        /// DateEqualSpecial | is | {expr1} = {expr2}
        /// DateEqualPrecise | is | {expr1} = {expr2}
        /// DateBeforeSpecial | is before(special date) 
        /// DateBeforePrecise | is before(precise date) 
        /// DateAfterSpecial | is after(special date) | {expr1} > {expr2}
        /// DateAfterSpecial | is after(precise date) | {expr1} > {expr2}
        /// </param>
        /// <param name="values"></param>
        public ConditionItem(string attrId, string @operator, params string[] values)
        {
            AttrId = attrId;
            Operator = @operator;
            Values = values;
        }

        public ConditionItem()
        {
        }

        public string AttrId { get; set; }
        public string Operator { get; set; }
        public string[] Values { get; set; }
    }
}