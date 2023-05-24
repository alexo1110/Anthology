namespace Anthology.Models
{
    public class SimLocation
    {
        /** x-coordinate of the location */
        public int X { get; set; }

        /** y-coordinate of the location */
        public int Y { get; set; }

        /** optional set of tags associated with the location. Eg. Restaurant could have 'food', 'delivery' as tags */
        public HashSet<string> Tags { get; set; } = new HashSet<String>();

        /** optional name of the location. Eg. Restaurant, Home, Movie Theatre, etc */
        public string Name { get; set; } = string.Empty;

        /** set of agents at the location */
        public HashSet<Agent> AgentsPresent { get; set; } = new HashSet<Agent>();

        /** returns true if the specified agent is at this location */
        public bool IsAgentHere(Agent npc)
        {
            return AgentsPresent.Contains(npc);
        }

        /** checks if this location satisfies all of the passed location requirements */
        public bool SatisfiesRequirements(RLocation reqs)
        {
            return HasAllOf(reqs.HasAllOf) &&
                   HasOneOrMoreOf(reqs.HasOneOrMoreOf) &&
                   HasNoneOf(reqs.HasNoneOf);
        }

        /** checks if this location satisfies all of the passed people requirements */
        public bool SatisfiesRequirements(RPeople reqs)
        {
            return HasMinNumPeople(reqs.MinNumPeople) &&
                   HasNotMaxNumPeople(reqs.MaxNumPeople) &&
                   SpecificPeoplePresent(reqs.SpecificPeoplePresent) &&
                   SpecificPeopleAbsent(reqs.SpecificPeopleAbsent) &&
                   RelationshipsPresent(reqs.RelationshipsPresent);
        }

        /** checks if this location satisfies the passed HasAllOf requirement */
        private bool HasAllOf(HashSet<string> hasAllOf)
        {
            return hasAllOf.IsSubsetOf(Tags);
        }

        /** checks if this location satisfies the HasOneOrMOreOf requirement */
        private bool HasOneOrMoreOf(HashSet<string> hasOneOrMoreOf)
        {
            return hasOneOrMoreOf.Overlaps(Tags);
        }

        /** checks if this location satisfies the HasNoneOf requirement */
        private bool HasNoneOf(HashSet<string> hasNoneOf)
        {
            return !hasNoneOf.Overlaps(Tags);
        }

        /** checks if this location satifies the MinNumPeople requirement */
        private bool HasMinNumPeople(short minNumPeople)
        {
            return minNumPeople < AgentsPresent.Count;
        }

        /** checks if this location satifies the MaxNumPeople requirement */
        private bool HasNotMaxNumPeople(short maxNumPeople)
        {
            return maxNumPeople >= AgentsPresent.Count;
        }

        /** checks if this location satifies the SpecificPeoplePresent requirement */
        private bool SpecificPeoplePresent(HashSet<Agent> specificPeoplePresent)
        {
            return specificPeoplePresent.IsSubsetOf(AgentsPresent);
        }

        /** checks if this location satisfies the SpecificPeopleAbsent requirement */
        private bool SpecificPeopleAbsent(HashSet<Agent> specificPeopleAbsent)
        {
            return !specificPeopleAbsent.Overlaps(AgentsPresent);
        }

        /** checks if this location satifies the RelationshipsPresent requirement */
        private bool RelationshipsPresent(HashSet<string> relationshipsPresent)
        {
            HashSet<string> relationshipsHere = new();
            foreach (Agent a in AgentsPresent)
            {
                HashSet<Relationship> ar = a.Relationships;
                foreach (Relationship r in ar)
                {
                    relationshipsHere.Add(r.Type);
                }
            }

            return relationshipsPresent.IsSubsetOf(relationshipsHere);
        }
    }
}
