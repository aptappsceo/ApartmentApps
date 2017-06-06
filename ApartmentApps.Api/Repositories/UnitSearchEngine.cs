using System.Linq;
using ApartmentApps.Data;
using ApartmentApps.Data.DataSheet;

namespace ApartmentApps.Api
{
    public class UnitSearchEngine : SearchEngine<Unit>
    {

        [Filter(nameof(CommonSearch),"Search",EditorTypes.TextField)]
        public IQueryable<Unit> CommonSearch(IQueryable<Unit> set, string query)
        {
            var tokenized = Tokenize(query);
            if (tokenized.Length <= 0) return set;
            return set.Where(unit => tokenized.Any(token => unit.Name.Contains(token) || unit.Users.Any(user=>user.FirstName.Contains(token) || user.LastName.Contains(token))));
        }

    }
}