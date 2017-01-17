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

        public MouseClick mouseClick { get { return (MouseClick)GetComponent(ComponentIds.MouseClick); } }
        public bool hasMouseClick { get { return HasComponent(ComponentIds.MouseClick); } }

        public Entity AddMouseClick(UnityEngine.Vector3 newScreenPosition) {
            var component = CreateComponent<MouseClick>(ComponentIds.MouseClick);
            component.screenPosition = newScreenPosition;
            return AddComponent(ComponentIds.MouseClick, component);
        }

        public Entity ReplaceMouseClick(UnityEngine.Vector3 newScreenPosition) {
            var component = CreateComponent<MouseClick>(ComponentIds.MouseClick);
            component.screenPosition = newScreenPosition;
            ReplaceComponent(ComponentIds.MouseClick, component);
            return this;
        }

        public Entity RemoveMouseClick() {
            return RemoveComponent(ComponentIds.MouseClick);
        }
    }

    public partial class Pool {

        public Entity mouseClickEntity { get { return GetGroup(Matcher.MouseClick).GetSingleEntity(); } }
        public MouseClick mouseClick { get { return mouseClickEntity.mouseClick; } }
        public bool hasMouseClick { get { return mouseClickEntity != null; } }

        public Entity SetMouseClick(UnityEngine.Vector3 newScreenPosition) {
            if(hasMouseClick) {
                throw new EntitasException("Could not set mouseClick!\n" + this + " already has an entity with MouseClick!",
                    "You should check if the pool already has a mouseClickEntity before setting it or use pool.ReplaceMouseClick().");
            }
            var entity = CreateEntity();
            entity.AddMouseClick(newScreenPosition);
            return entity;
        }

        public Entity ReplaceMouseClick(UnityEngine.Vector3 newScreenPosition) {
            var entity = mouseClickEntity;
            if(entity == null) {
                entity = SetMouseClick(newScreenPosition);
            } else {
                entity.ReplaceMouseClick(newScreenPosition);
            }

            return entity;
        }

        public void RemoveMouseClick() {
            DestroyEntity(mouseClickEntity);
        }
    }

    public partial class Matcher {

        static IMatcher _matcherMouseClick;

        public static IMatcher MouseClick {
            get {
                if(_matcherMouseClick == null) {
                    var matcher = (Matcher)Matcher.AllOf(ComponentIds.MouseClick);
                    matcher.componentNames = ComponentIds.componentNames;
                    _matcherMouseClick = matcher;
                }

                return _matcherMouseClick;
            }
        }
    }
}
