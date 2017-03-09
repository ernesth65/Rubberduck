//using System.Linq;
//using System.Threading;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using Rubberduck.Inspections;
//using Rubberduck.Inspections.QuickFixes;
//using Rubberduck.Parsing.VBA;
//using Rubberduck.VBEditor.SafeComWrappers.Abstract;
//using RubberduckTests.Mocks;

//namespace RubberduckTests.Inspections
//{
//    [TestClass]
//    public class IgnoreOnceQuickFixTests
//    {
//        [TestMethod]
//        public void AnnotationListFollowedByCommentAddsAnnotationCorrectly()
//        {
//            // Arrange
//            const string inputCode = @"
//Public Function GetSomething() As Long
//    '@Ignore VariableNotAssigned: Is followed by a comment.
//    Dim foo As Long
//    GetSomething = foo
//End Function
//";

//            const string expectedCode = @"
//Public Function GetSomething() As Long
//    '@Ignore UnassignedVariableUsage, VariableNotAssigned: Is followed by a comment.
//    Dim foo As Long
//    GetSomething = foo
//End Function
//";

//            var builder = new MockVbeBuilder();
//            IVBComponent component;
//            var vbe = builder.BuildFromSingleStandardModule(inputCode, out component);
//            var project = vbe.Object.VBProjects[0];
//            var module = project.VBComponents[0].CodeModule;
//            var parser = MockParser.Create(vbe.Object, new RubberduckParserState(vbe.Object));

//            parser.Parse(new CancellationTokenSource());
//            if (parser.State.Status >= ParserState.Error) { Assert.Inconclusive("Parser Error"); }

//            var inspection = new UnassignedVariableUsageInspection(parser.State);
//            var inspectionResults = inspection.GetInspectionResults();

//            inspectionResults.First().QuickFixes.Single(s => s is IgnoreOnceQuickFix).Fix();

//            var actualCode = module.Content();

//            Assert.AreEqual(expectedCode, actualCode);
//        }

//    }
//}
