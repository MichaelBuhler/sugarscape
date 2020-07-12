
using System.Collections.Generic;

public class Simulation {

    public enum MovementStrategies {
        CLASSIC,
        CUSTOM
    }

    public static class Parameters {
        public static int SUGAR_GROWTH_RATE = 1;
        public static int INITIAL_NUMBER_OF_AGENTS = 400;
        public static class Endowment {
            public static int MIN = 50;
            public static int MAX = 100;
        }
        public static class Vision {
            public static int MIN = 1;
            public static int MAX = 6;
        }
        public static class Metabolism {
            public static int MIN = 1;
            public static int MAX = 4;
        }
        public static class Lifespan {
            public static int MIN = 60;
            public static int MAX = 100;
        }
        public static class Fertility {
            public static class Male {
                public static class Begin {
                    public static int MIN = 12;
                    public static int MAX = 15;
                }
                public static class End {
                    public static int MIN = 50;
                    public static int MAX = 60;
                }
            }
            public static class Female {
                public static class Begin {
                    public static int MIN = 12;
                    public static int MAX = 15;
                }
                public static class End {
                    public static int MIN = 40;
                    public static int MAX = 50;
                }
            }
        }
        public static MovementStrategies MOVEMENT_STRATEGY = MovementStrategies.CLASSIC;
    }

    public static int CURRENT_STEP { get; private set; } = 0;

    public static Environment environment;
    public static List<Agent> agents;

    public static void Init () {
        CURRENT_STEP = 0;
        InitEnvironment();
        InitAgents();
    }

    public static bool Step () {
        List<Agent> liveAgents = agents.FindAll(x => x.isAlive);
        if ( liveAgents.Count == 0 ) {
            return false;
        }
        foreach ( Agent agent in Utils.Shuffle(liveAgents)) {
            agent.Step();
        }
        environment.Step();
        CURRENT_STEP++;
        return true;
    }

    public static void Render () {
        environment.Render();
        foreach ( Agent agent in agents.FindAll(x => x.isAlive) ) {
            agent.Render();
        }
    }

    private static void InitEnvironment () {
        if ( environment != null ) {
            environment.Destroy();
        }
        environment = new Environment();
    }

    private static void InitAgents () {
        if ( agents != null ) {
            foreach ( Agent agent in agents ) {
                agent.Destroy();
            }
        }
        agents = new List<Agent>();
        for ( int i = 0 ; i < Parameters.INITIAL_NUMBER_OF_AGENTS ; i++ ) {
            Agent agent = new Agent();
            Location location = environment.GetUnoccupiedLocation();
            agent.location = location;
            location.agent = agent;
            agents.Add(agent);
        }
    }

}  
