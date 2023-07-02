namespace Anthology.Models
{
    /** Provides functionality for checking location-centric conditions */
    public static class LocationManager
    {
        /** Locations in the simulation as a set for set operations */
        public static HashSet<SimLocation> LocationSet { get; set; } = new HashSet<SimLocation>();

        /** Locations in the simulation as a grid for coordinate access */
        public static Dictionary<int, Dictionary<int, SimLocation>> LocationGrid { get; set; } = new Dictionary<int, Dictionary<int, SimLocation>>();

        /** Initialize/reset all static location manager variables and fill an empty N x N grid */
        public static void Init(int n, string path)
        {
            LocationSet.Clear();
            LocationGrid.Clear();
            for (int i = 0; i < n; i++)
            {
                LocationGrid[i] = new Dictionary<int, SimLocation>();
                for (int k = 0; k < n; k++)
                {
                    LocationGrid[i][k] = new SimLocation();
                }
            }
            World.ReadWrite.LoadLocationsFromFile(path);
        }

        /** Add a location to both the location set and the location grid */
        public static void AddLocation(SimLocation location)
        {
            foreach (Agent a in AgentManager.Agents)
            {
                if (a.XLocation == location.X && a.YLocation == location.Y)
                {
                    location.AgentsPresent.Add(a.Name);
                }
            }
            LocationSet.Add(location);
            LocationGrid[location.X][location.Y] = location;
        }

        /** Finds the location with the matching name */
        public static SimLocation GetSimLocationByName(string name)
        {
            bool IsNameMatch(SimLocation location)
            {
                return location.Name == name;
            }

            SimLocation location = LocationSet.First(IsNameMatch);
            return location;
        }

        /** Gets the set of all named locations in the square area defined by the given center coordinates and radius */
        public static HashSet<SimLocation> GetSimLocationsByArea(int centerX, int centerY, int radius)
        {
            HashSet<SimLocation> areaSet = new();
            int startX = centerX < radius ? 0 : centerX - radius;
            int startY = centerY < radius ? 0 : centerY - radius;
            int endX = centerX + radius;
            int endY = centerY + radius;
            if (UI.GridSize <= endX) endX = UI.GridSize - 1;
            if (UI.GridSize <= endY) endY = UI.GridSize - 1;

            SimLocation loc = new();
            for(int x = startX; x <= endX; x++)
            {
                for (int y = startY; y <= endY; y++)
                {
                    loc = LocationGrid[x][y];
                    if (loc.Name != string.Empty)
                    {
                        areaSet.Add(loc);
                    }
                }
            }
            return areaSet;
        }

        /** Gets the set of all named locations in the square (not the area) defined by the given center coordinates and radius */
        public static HashSet<SimLocation> GetSimLocationsBySquare(int centerX, int centerY, int radius)
        {
            HashSet<SimLocation> squareSet = new();
            int left = centerX - radius;
            int right = centerX + radius;
            int bot = centerY - radius;
            int top = centerY + radius;
            bool leftValid = left >= 0;
            bool rightValid = right <= UI.GridSize;
            bool botValid = bot >= 0;
            bool topValid = top <= UI.GridSize;
            SimLocation loc;

            if (botValid)
            {
                for (int x = left; x <= right; x++)
                {
                    if (x >= 0 && x <= UI.GridSize)
                    {
                        loc = LocationGrid[x][bot];
                        if (loc.Name != string.Empty)
                            squareSet.Add(loc);
                    }
                }
            }
            if (topValid)
            {
                for (int x = left; x <= right; x++)
                {
                    if (x >= 0 && x <= UI.GridSize)
                    {
                        loc = LocationGrid[x][top];
                        if (loc.Name != string.Empty)
                            squareSet.Add(loc);
                    }
                }
            }
            if (leftValid)
            {
                for (int y = bot + 1; y < top; y++)
                {
                    if (y >=  0 && y <= UI.GridSize)
                    {
                        loc = LocationGrid[left][y];
                        if (loc.Name != string.Empty)
                            squareSet.Add(loc);
                    }
                }
            }
            if (rightValid)
            {
                for (int y = bot + 1; y < top; y++)
                {
                    if (y >= 0 && y <= UI.GridSize)
                    {
                        loc = LocationGrid[right][y];
                        if (loc.Name != string.Empty)
                            squareSet.Add(loc);
                    }
                }
            }
            return squareSet;
        }

        /** 
         * Filter given set of locations to find those locations that satisfy conditions specified in the location requirement
         * Returns a set of locations that match the HasAllOf, HasOneOrMOreOf, and HasNoneOf constraints
         * Returns all the locations that satisfied the given requirement, or an empty set is none match.
         */
        public static HashSet<SimLocation> LocationsSatisfyingLocationRequirement(HashSet<SimLocation> locations, RLocation requirements, string agent = "")
        {
            bool IsLocationInvalid(SimLocation location)
            {   
                if (agent == "" || location.AgentsPresent.Contains(agent))
                {
                    return !location.SatisfiesRequirements(requirements);
                }
                else
                {
                    location.AgentsPresent.Add(agent);
                    bool invalid = !location.SatisfiesRequirements(requirements);
                    location.AgentsPresent.Remove(agent);
                    return invalid;
                }
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
        public static HashSet<SimLocation> LocationsSatisfyingPeopleRequirement(HashSet<SimLocation> locations, RPeople requirements, string agent = "")
        {
            bool IsLocationInvalid(SimLocation location)
            {
                if (agent == "" || location.AgentsPresent.Contains(agent))
                {
                    return !location.SatisfiesRequirements(requirements);
                }
                else
                {
                    location.AgentsPresent.Add(agent);
                    bool invalid = !location.SatisfiesRequirements(requirements);
                    location.AgentsPresent.Remove(agent);
                    return invalid;
                }
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
            SimLocation locFrom = LocationGrid[from.XLocation][from.YLocation];
            return FindNearestLocationFrom(locations, locFrom);
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
            HashSet<SimLocation> locationsToCheck = new();
            locationsToCheck.UnionWith(locations);

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
