using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Diaballik;
using System.Drawing;

namespace TestModel
{
    class FactoryTest
    {
        public static PlayerBuilder getPlayerBuilderHuman(Color c, String name)
        {
            PlayerBuilder playerBuilder = PlayerHumanBuilder.create();
            playerBuilder.Color = c;
            playerBuilder.Name = name;
            return playerBuilder;
        }

        public static PlayerBuilder getPlayerBuilderIA(Color c, String name)
        {
            PlayerIABuilder playerBuilder = new PlayerIABuilder();
            playerBuilder.Color = c;
            playerBuilder.Name = name;
            playerBuilder.IaStrategy = new Noob();
            return playerBuilder;
        }

        public static Game getRandomGame()
        {
            GameBuilder gameBuilder = GameBuilder.create();
            gameBuilder.Player1 = FactoryTest.getPlayerBuilderHuman(Color.Red, "test");
            gameBuilder.Player2 = FactoryTest.getPlayerBuilderHuman(Color.Blue, "test2");
            gameBuilder.Scenario = new Standart();
            return gameBuilder.build();
        }

        public static Game getGameWithScenario(Scenario sce)
        {
            GameBuilder gameBuilder = GameBuilder.create();
            gameBuilder.Player1 = FactoryTest.getPlayerBuilderHuman(Color.Red, "test");
            gameBuilder.Player2 = FactoryTest.getPlayerBuilderHuman(Color.Blue, "test2");
            gameBuilder.Scenario = sce;
            return gameBuilder.build();
        }
    }
}
