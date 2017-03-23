using System;
using System.Linq;
using System.Collections.Generic;
using Cyprom.TableTennisTournaments.Model;

namespace Cyprom.TableTennisTournaments.Data.Repositories
{
    public class TableRepository : Repository<Table>
    {
        protected override string TableName
        {
            get
            {
                return "Table";
            }
        }

        protected override Dictionary<string, object> ObjectToDictionary(Table obj)
        {
            var dict = new Dictionary<string, object>();
            dict["ID"] = (obj == null ? Guid.Empty : obj.ID);
            dict["Number"] = (obj == null ? 0 : obj.Number);
            dict["TournamentID"] = (obj == null ? Guid.Empty : obj.Tournament.ID);
            dict["MatchIDs"] = (obj == null ? string.Empty : ListJoin(obj.Matches.Select(m => m.ID.ToString()).ToArray()));
            return dict;
        }

        protected override Table DictionaryToObject(Dictionary<string, object> dict)
        {
            var id = (Guid)dict["ID"];
            var number = (short)dict["Number"];
            var tournamentID = (Guid)dict["TournamentID"];
            var matchIDs = ListSplit(dict["MatchIDs"].ToString()).Select(s => Guid.Parse(s)).ToList();
            //var obj = new Table(ModelManager.GetTournament(tournamentID), number);
            // TODO: Complete
            return null;
        }
    }
}
