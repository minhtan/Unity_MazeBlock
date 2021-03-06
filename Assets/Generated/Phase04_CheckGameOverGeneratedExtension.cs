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

        static readonly Phase04_CheckGameOver phase04_CheckGameOverComponent = new Phase04_CheckGameOver();

        public bool isPhase04_CheckGameOver {
            get { return HasComponent(ComponentIds.Phase04_CheckGameOver); }
            set {
                if(value != isPhase04_CheckGameOver) {
                    if(value) {
                        AddComponent(ComponentIds.Phase04_CheckGameOver, phase04_CheckGameOverComponent);
                    } else {
                        RemoveComponent(ComponentIds.Phase04_CheckGameOver);
                    }
                }
            }
        }

        public Entity IsPhase04_CheckGameOver(bool value) {
            isPhase04_CheckGameOver = value;
            return this;
        }
    }

    public partial class Pool {

        public Entity phase04_CheckGameOverEntity { get { return GetGroup(Matcher.Phase04_CheckGameOver).GetSingleEntity(); } }

        public bool isPhase04_CheckGameOver {
            get { return phase04_CheckGameOverEntity != null; }
            set {
                var entity = phase04_CheckGameOverEntity;
                if(value != (entity != null)) {
                    if(value) {
                        CreateEntity().isPhase04_CheckGameOver = true;
                    } else {
                        DestroyEntity(entity);
                    }
                }
            }
        }
    }

    public partial class Matcher {

        static IMatcher _matcherPhase04_CheckGameOver;

        public static IMatcher Phase04_CheckGameOver {
            get {
                if(_matcherPhase04_CheckGameOver == null) {
                    var matcher = (Matcher)Matcher.AllOf(ComponentIds.Phase04_CheckGameOver);
                    matcher.componentNames = ComponentIds.componentNames;
                    _matcherPhase04_CheckGameOver = matcher;
                }

                return _matcherPhase04_CheckGameOver;
            }
        }
    }
}
