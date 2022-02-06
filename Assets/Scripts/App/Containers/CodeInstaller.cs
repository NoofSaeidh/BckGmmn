using System;
using System.Collections.Generic;
using System.Linq;
using BckGmmn.Core;
using BckGmmn.Core.Backgammon;
using BckGmmn.Core.Common;
using BckGmmn.Core.DefaultImplementations;
using UnityEngine;
using Zenject;

namespace BckGmmn.App.Containers
{
    public class CodeInstaller : Installer<CodeInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<IGame>().To<BackgammonGame>().AsSingle();
            Container.Bind<IDie>().To<Die>().AsSingle();
            Container.Bind<IDice>().To<Dice>().AsSingle();
            Container.Bind<ICheckerMove>().To<CheckerMove>().AsSingle();
            Container.Bind<IFullMove>().To<FullMove>().AsSingle();
            Container.Bind<IRules>().To<BackgammonRules>().AsSingle();
            Container.Bind<IDiceValueGenerator>().To<SystemRandomDiceValueGenerator>().AsSingle();

            BindPlayer(PlayerId.PlayerA);
            BindPlayer(PlayerId.PlayerB);
            void BindPlayer(PlayerId player)
            {
                Container
                    .Bind<IPlayer>()
                    .WithId(player)
                    .To<Player>()
                    .AsCached()
                    .WithArguments(PlayerId.PlayerA)
                    .OnInstantiated<Player>((ctx, pl) => pl._game = ctx.Container.Resolve<IGame>());
            }

            BindQuadrant(QuadrantIndex.A);
            BindQuadrant(QuadrantIndex.B);
            BindQuadrant(QuadrantIndex.C);
            BindQuadrant(QuadrantIndex.D);
            void BindQuadrant(QuadrantIndex index)
            {
                Container.Bind<IQuadrant>()
                    .WithId(index)
                    .To<Quadrant>()
                    .AsCached()
                    .WithArguments(index)
                    .OnInstantiated<Quadrant>((ctx, q) => 
                        q.Points = ctx.Container.Resolve<IReadOnlyCollection<Point>>().Where(p => p.Index.Quadrant == index).ToList());
            }

            Container.BindInstance(new Bar());
            Container.BindInstance(new BorneOff());
            Container.BindInstance(Board.GetPoints());
            Container.Bind<IReadOnlyCollection<Checker>>()
                .FromMethod(ctx => Board.GetCheckers(ctx.Container.Resolve<IRules>()));
            Container.Bind<IBoard>().To<Board>().AsSingle();

        }
    }
}