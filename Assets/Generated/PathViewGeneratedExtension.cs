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

        public PathView pathView { get { return (PathView)GetComponent(ComponentIds.PathView); } }
        public bool hasPathView { get { return HasComponent(ComponentIds.PathView); } }

        public Entity AddPathView(UnityEngine.LineRenderer newLine) {
            var component = CreateComponent<PathView>(ComponentIds.PathView);
            component.line = newLine;
            return AddComponent(ComponentIds.PathView, component);
        }

        public Entity ReplacePathView(UnityEngine.LineRenderer newLine) {
            var component = CreateComponent<PathView>(ComponentIds.PathView);
            component.line = newLine;
            ReplaceComponent(ComponentIds.PathView, component);
            return this;
        }

        public Entity RemovePathView() {
            return RemoveComponent(ComponentIds.PathView);
        }
    }

    public partial class Matcher {

        static IMatcher _matcherPathView;

        public static IMatcher PathView {
            get {
                if(_matcherPathView == null) {
                    var matcher = (Matcher)Matcher.AllOf(ComponentIds.PathView);
                    matcher.componentNames = ComponentIds.componentNames;
                    _matcherPathView = matcher;
                }

                return _matcherPathView;
            }
        }
    }
}