
using System.Collections.Generic;

public class Simulation {

    public static class Parameters {
        public static int NUMBER_OF_AGENTS = 400;
        public static class Endowment {
            public static int MIN = 20;
            public static int MAX = 40;
        }
        public static class Vision {
            public static int MIN = 1;
            public static int MAX = 6;
        }
        public static class Metabolism {
            public static int MIN = 1;
            public static int MAX = 4;
        }
    }

    public static Environment environment = new Environment();
    public static List<Agent> agents = new List<Agent>();

    public static void Init () {
        for ( int i = 0 ; i < Parameters.NUMBER_OF_AGENTS ; i++ ) {
            Agent agent = new Agent();
            Location location = environment.GetUnoccupiedLocation();
            agent.location = location;
            location.agent = agent;
            agents.Add(agent);
        }
    }

    public static void Render () {
        environment.Render();
        foreach ( Agent agent in agents ) {
            agent.Render();
        }
    }
}  
