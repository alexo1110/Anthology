namespace Anthology.Models
{
    /** Provides functionality for checking location-centric conditions */
    public static class LocationManager
    {
        /** Locations in the simulation */
        public static HashSet<SimLocation> SimLocations { get; set; } = new HashSet<SimLocation>();

        /** Initialize/reset all static location manager variables */
        public static void Init()
        {
            SimLocations.Clear();
        }

        /** 
         * Filter given set of locations to find those locations that satisfy conditions specified in the location requirement
         * Returns a set of locations that match the HasAllOf, HasOneOrMOreOf, and HasNoneOf constraints
         * Returns all the locations that satisfied the given requirement, or an empty set is none match.
         */
        public static HashSet<SimLocation> LocationsSatisfyingLocationRequirement(HashSet<SimLocation> locations, RLocation requirements)
        {
            bool IsLocationInvalid(SimLocation location)
            {
                return !location.SatisfiesRequirements(requirements);
            }

            HashSet<SimLocation> satisfactoryLocations = new();
            satisfactoryLocations.UnionWith(locations);
            satisfactoryLocations.RemoveWhere(IsLocationInvalid);

            return satisfactoryLocations;
        }

        /**
         * Filter given set of locations to find those locations that satisfy conditions specified in the people requirement
         * Returns a set of locations that match the MinNumPeople, MaxNumPeople, SpecificPeoplePresent, SpecificPeopleAbsent,
         * RelationshipsPresent, and RelationshipsAbsent requirements
         * Returns all the locations that satisfied the given requirement, or an empty set is none match.
         */
        public static HashSet<SimLocation> LocationsSatisfyingPeopleRequirement(HashSet<SimLocation> locations, RPeople requirements)
        {
            bool IsLocationInvalid(SimLocation location)
            {
                return !location.SatisfiesRequirements(requirements);
            }

            HashSet<SimLocation> satisfactoryLocations = new();
            satisfactoryLocations.UnionWith(locations);
            satisfactoryLocations.RemoveWhere(IsLocationInvalid);

            return satisfactoryLocations;
        }

        /** Returns the SimLocation at the given (X,Y) coordinates, or null if one does not exist */
        public static SimLocation? FindSimLocationAt(HashSet<SimLocation> locations, float x, float y)
        {
            foreach (SimLocation loc in locations)
            {
                if (loc.X == x && loc.Y == y)
                {
                    return loc;
                }
            }
            return null;
        }

        /** Returns the SimLocation nearest the given SimLocation, or null if one does not exist */
        public static SimLocation? FindNearestLocationFrom(HashSet<SimLocation> locations, SimLocation from)
        {
            return FindNearestLocationXY(locations, from.X, from.Y);
        }

        /** Returns the SimLocation nearest the given Agent, or null if one does not exist */
        public static SimLocation? FindNearestLocationFrom(HashSet<SimLocation> locations, Agent from)
        {
            return FindNearestLocationFrom(locations, from.CurrentLocation);
        }


        /** Find the manhattan distance between two locations */
        public static int FindManhattanDistance(SimLocation a, SimLocation b)
        {
            return Math.Abs(a.X - b.X) + Math.Abs(a.Y - b.Y);
        }

        /** Find the manhattan distance between a location and specified (X,Y) coordinates */
        public static int FindManhattanDistance(SimLocation loc, int x, int y)
        {
            return Math.Abs(loc.X - x) + Math.Abs(loc.Y - y);
        }

        /** Helper function that finds the location nearest to the given (X,Y) coordinate */
        private static SimLocation? FindNearestLocationXY(HashSet<SimLocation> locations, int x, int y)
        {
            bool IsSameLocation(SimLocation loc)
            {
                return loc.X == x && loc.Y == y;
            }
            HashSet<SimLocation> locationsToCheck = new();
            locationsToCheck.UnionWith(locations);
            locationsToCheck.RemoveWhere(IsSameLocation);

            if (locationsToCheck.Count == 0) return null;

            HashSet<SimLocation> closestSet = new();
            int closestDist = int.MaxValue;

            foreach (SimLocation loc in locationsToCheck)
            {
                int dist = FindManhattanDistance(loc, x, y);
                if (dist < closestDist)
                {
                    closestDist = dist;
                    closestSet.Clear();
                    closestSet.Add(loc);
                }
                else if (dist == closestDist)
                {
                    closestSet.Add(loc);
                }
            }

            Random r = new();
            int idx = r.Next(0, closestSet.Count);
            return closestSet.ElementAt(idx);
        }
    }
}
