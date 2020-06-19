
using System.Collections.Generic;

public class Simulation {

    public static class Parameters {
        public static int NUMBER_OF_AGENTS = 400;
    }

    public static Environment environment = new Environment();
    public static List<Agent> agents = new List<Agent>();

    public static void Init () {
        for ( int i = 0 ; i < Parameters.NUMBER_OF_AGENTS ; i++ ) {
            Agent agent = new Agent(i);
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
