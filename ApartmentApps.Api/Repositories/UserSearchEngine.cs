using System.Linq;
using ApartmentApps.Data;
using ApartmentApps.Data.DataSheet;

namespace ApartmentApps.Api
{
    public class UserSearchEngine : SearchEngine<ApplicationUser>
    {

        public IQueryable<ApplicationUser> CommonSearch(IQueryable<ApplicationUser> set, string query)
        {
            var tokenized = Tokenize(query);
            if (tokenized.Length <= 0) return set;
            return
                set.Where(
                    _ =>
                        tokenized.Any(
                            token =>
                                _.FirstName.Contains(token) || _.LastName.Contains(token) || _.Email.Contains(token)));
        }
    }
}