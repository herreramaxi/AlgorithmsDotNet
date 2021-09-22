using System.Collections.Generic;

namespace _5TreesAndGraphs
{
    public class ActorGraphNode
    {
        public int BaconNumber { get; set; } = -1;
        public string Name { get; private set; }
        public HashSet<ActorGraphNode> LinkedActors { get; private set; } = new HashSet<ActorGraphNode>();

        public ActorGraphNode(string name)
        {
            this.Name = name;
        }

        public void LinkCostar(ActorGraphNode costar)
        {
            this.LinkedActors.Add(costar);
            costar.LinkedActors.Add(this);
        }

        /// <summary>
        /// Cal this method from Kevin Bacon
        /// </summary>
        public void SetBaconNumber()
        {
            this.BaconNumber = 0;
            var queue = new Queue<ActorGraphNode>();
            queue.Enqueue(this);

            while (queue.Count > 0) {

                var current = queue.Dequeue();

                foreach (var linkedActor  in current.LinkedActors)
                {
                    //no visited
                    if (linkedActor.BaconNumber == -1) {
                        linkedActor.BaconNumber = current.BaconNumber + 1;
                        queue.Enqueue(linkedActor);
                    }
                }
            }
        }

        public int SearchBaconNumberFor(ActorGraphNode actor)
        {
            this.BaconNumber = 0;
            var queue = new Queue<ActorGraphNode>();
            queue.Enqueue(this);

            while (queue.Count > 0)
            {
                var current = queue.Dequeue();

                if (current == actor) return actor.BaconNumber;

                foreach (var linkedActor in current.LinkedActors)
                {
                    //no visited
                    if (linkedActor.BaconNumber == -1)
                    {
                        linkedActor.BaconNumber = current.BaconNumber + 1;
                        queue.Enqueue(linkedActor);
                    }
                }
            }

            return -1;
        }
    }
}
