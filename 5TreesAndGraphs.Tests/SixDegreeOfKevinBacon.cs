using NUnit.Framework;

namespace _5TreesAndGraphs.Tests
{
    [TestFixture]
    public class SixDegreeOfKevinBacon
    {
        [Test]
        public void Test() {
            var kb = new ActorGraphNode("Kevin Bacon");
            var a = new ActorGraphNode("Actor A");
            var b = new ActorGraphNode("Actor B");
            var m = new ActorGraphNode("Actor M");
            var c = new ActorGraphNode("Actor C");
            var d = new ActorGraphNode("Actor D");
            var e= new ActorGraphNode("Actor E");
            var f = new ActorGraphNode("Actor F");
            var g = new ActorGraphNode("Actor G");
            var h = new ActorGraphNode("Actor H");

            //Longest bacon number: 4
            kb.LinkCostar(a);
            a.LinkCostar(b);
            b.LinkCostar(m);
            m.LinkCostar(c);

            //shortest bacon number: 3
            kb.LinkCostar(d);
            d.LinkCostar(e);
            e.LinkCostar(c);
            
            //No linked actors
            f.LinkCostar(g);
            g.LinkCostar(h);


            Assert.AreEqual(3, kb.SearchBaconNumberFor(c));
            Assert.AreEqual(-1, kb.SearchBaconNumberFor(f));
            Assert.AreEqual(-1, kb.SearchBaconNumberFor(g));
        }
    }
}
