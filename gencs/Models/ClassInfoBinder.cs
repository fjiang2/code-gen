using System.CommandLine;
using System.CommandLine.Binding;

namespace gencs.Models
{
    public class ClassInfoBinder : BinderBase<ClassInfo>
    {
        private readonly Option<IEnumerable<string>> usings;
        private readonly Option<string> nameSpace;
        private readonly Argument<string> className;
        private readonly Option<IEnumerable<string>> bases;

        public ClassInfoBinder(Option<IEnumerable<string>> usings, Option<string> nameSpace, Argument<string> className, Option<IEnumerable<string>> bases)
        {
            this.usings = usings;
            this.nameSpace = nameSpace;
            this.className = className;
            this.bases = bases;
        }

        protected override ClassInfo GetBoundValue(BindingContext bindingContext) =>
        new ClassInfo
        {
            Usings = (bindingContext.ParseResult.GetValueForOption(usings) ?? new string[0]).ToArray(),
            NameSpace = bindingContext.ParseResult.GetValueForOption(nameSpace) ?? string.Empty,
            ClassName = bindingContext.ParseResult.GetValueForArgument(className),
            Bases = (bindingContext.ParseResult.GetValueForOption(bases) ?? new string[0]).ToArray(),
        };
    }
}
