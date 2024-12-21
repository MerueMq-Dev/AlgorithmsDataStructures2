using FluentAssertions;
using Xunit;

namespace AlgorithmsDataStructures2.Tests
{
    public class SimpleGraphTests
    {
        [Fact]
        public void AddVertex_ShouldCreateNewVertexWithoutEdges()
        {
            SimpleGraph simpleGraph = new SimpleGraph(2);
            simpleGraph.AddVertex(2);

            simpleGraph.vertex.Should().Contain(x => x.Value == 2);
        }

        [Fact]
        public void AddEdge_ShouldAddEdgeBetweenTwoVertices()
        {
            SimpleGraph simpleGraph = new SimpleGraph(2);
            simpleGraph.AddVertex(2);
            simpleGraph.AddVertex(3);

            simpleGraph.IsEdge(0, 1).Should().BeFalse();
            simpleGraph.IsEdge(1, 0).Should().BeFalse();

            simpleGraph.AddEdge(0, 1);

            simpleGraph.IsEdge(0, 1).Should().BeTrue();
            simpleGraph.IsEdge(1, 0).Should().BeTrue();
        }

        [Fact]
        public void RemoveEdge_ShouldRemoveEdgeBetweenTwoVertices()
        {
            SimpleGraph simpleGraph = new SimpleGraph(2);
            simpleGraph.AddVertex(2);
            simpleGraph.AddVertex(3);
            simpleGraph.AddEdge(0, 1);
            simpleGraph.IsEdge(0, 1).Should().BeTrue();
            simpleGraph.IsEdge(1, 0).Should().BeTrue();

            simpleGraph.RemoveEdge(0, 1);

            simpleGraph.IsEdge(0, 1).Should().BeFalse();
            simpleGraph.IsEdge(1, 0).Should().BeFalse();
        }

        [Fact]
        public void RemoveVertex_ShouldDeleteVertexAndAllConnectedEdges()
        {
            SimpleGraph simpleGraph = new SimpleGraph(4);
            simpleGraph.AddVertex(1);
            simpleGraph.AddVertex(2);
            simpleGraph.AddVertex(3);
            simpleGraph.AddVertex(4);
            simpleGraph.AddEdge(1, 2);
            simpleGraph.AddEdge(0, 3);
            simpleGraph.AddEdge(3, 1);
            simpleGraph.AddEdge(2, 0);

            simpleGraph.RemoveVertex(2);

            simpleGraph.IsEdge(1, 2).Should().BeFalse();
            simpleGraph.IsEdge(2, 0).Should().BeFalse();
            simpleGraph.IsEdge(0, 3).Should().BeTrue();
        }
    }
}