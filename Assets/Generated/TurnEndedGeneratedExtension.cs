//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGenerator.ComponentExtensionsGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
namespace Entitas {

    public partial class Entity {

        public TurnEnded turnEnded { get { return (TurnEnded)GetComponent(ComponentIds.TurnEnded); } }
        public bool hasTurnEnded { get { return HasComponent(ComponentIds.TurnEnded); } }

        public Entity AddTurnEnded(Player newPlayer) {
            var component = CreateComponent<TurnEnded>(ComponentIds.TurnEnded);
            component.player = newPlayer;
            return AddComponent(ComponentIds.TurnEnded, component);
        }

        public Entity ReplaceTurnEnded(Player newPlayer) {
            var component = CreateComponent<TurnEnded>(ComponentIds.TurnEnded);
            component.player = newPlayer;
            ReplaceComponent(ComponentIds.TurnEnded, component);
            return this;
        }

        public Entity RemoveTurnEnded() {
            return RemoveComponent(ComponentIds.TurnEnded);
        }
    }

    public partial class Pool {

        public Entity turnEndedEntity { get { return GetGroup(Matcher.TurnEnded).GetSingleEntity(); } }
        public TurnEnded turnEnded { get { return turnEndedEntity.turnEnded; } }
        public bool hasTurnEnded { get { return turnEndedEntity != null; } }

        public Entity SetTurnEnded(Player newPlayer) {
            if(hasTurnEnded) {
                throw new EntitasException("Could not set turnEnded!\n" + this + " already has an entity with TurnEnded!",
                    "You should check if the pool already has a turnEndedEntity before setting it or use pool.ReplaceTurnEnded().");
            }
            var entity = CreateEntity();
            entity.AddTurnEnded(newPlayer);
            return entity;
        }

        public Entity ReplaceTurnEnded(Player newPlayer) {
            var entity = turnEndedEntity;
            if(entity == null) {
                entity = SetTurnEnded(newPlayer);
            } else {
                entity.ReplaceTurnEnded(newPlayer);
            }

            return entity;
        }

        public void RemoveTurnEnded() {
            DestroyEntity(turnEndedEntity);
        }
    }

    public partial class Matcher {

        static IMatcher _matcherTurnEnded;

        public static IMatcher TurnEnded {
            get {
                if(_matcherTurnEnded == null) {
                    var matcher = (Matcher)Matcher.AllOf(ComponentIds.TurnEnded);
                    matcher.componentNames = ComponentIds.componentNames;
                    _matcherTurnEnded = matcher;
                }

                return _matcherTurnEnded;
            }
        }
    }
}