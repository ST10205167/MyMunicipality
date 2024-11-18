using MyMunicipality.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMunicipality.DataStructures
{
    /// <summary>
    /// This class implements a singleton Tree structure to store and manage service requests.
    /// </summary>
    public class ServiceRequestTree
    {
        private static ServiceRequestTree _instance;

        private TreeNode root;

        private static int requestIdCounter = 1;

        /// <summary>
        /// Private constructor to initialize the tree with some preloaded data.
        /// </summary>
        public ServiceRequestTree()
        {
            root = null; 
            AddPreloadedData();
        }

        /// <summary>
        /// Property to get the singleton instance of the ServiceRequestTree.
        /// </summary>
        public static ServiceRequestTree Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ServiceRequestTree();
                }
                return _instance;
            }
        }

        /// <summary>
        /// Method to add some preloaded service requests to the tree.
        /// </summary>
        private void AddPreloadedData()
        {
            var preloadedRequests = new List<ServiceRequests>
            {
                new ServiceRequests(requestIdCounter++, "Pending", "Water", "Fix the broken pipe at Main Street", DateTime.Now.AddDays(-2), "Main Street", "pack://application:,,,/Resources/pipeburst.png", null, "image"),
                new ServiceRequests(requestIdCounter++, "Completed", "Roads", "Repair street roads of potholes", DateTime.Now.AddDays(-4), "5th Avenue", "Resources/road.jpg", null, "image"),
                new ServiceRequests(requestIdCounter++, "Pending", "Sanitation", "Clean up the trash in the streets", DateTime.Now.AddDays(-1), "Central Park", "Resources/dirtyroad.jpg", null, "image")
            };

            foreach (var request in preloadedRequests)
            {
                AddRequest(request);
            }
        }

        /// <summary>
        /// Adds a new service request to the tree.
        /// </summary>
        /// <param name="request">The service request to be added.</param>
        public void AddRequest(ServiceRequests request)
        {
            root = Insert(root, request);
        }

        /// <summary>
        /// Recursively inserts a service request into the binary search tree.
        /// </summary>
        /// <param name="node">The current node in the tree.</param>
        /// <param name="request">The service request to insert.</param>
        /// <returns>The updated node after insertion.</returns>
        private TreeNode Insert(TreeNode node, ServiceRequests request)
        {
            if (node == null)
                return new TreeNode(request);

            if (request.Id < node.Request.Id)
                node.Left = Insert(node.Left, request);
            else if (request.Id > node.Request.Id)
                node.Right = Insert(node.Right, request); 

            return node;
        }

        /// <summary>
        /// Retrieves all service requests in the tree, sorted by request ID.
        /// </summary>
        /// <returns>A list of all service requests in ascending order of their IDs.</returns>
        public List<ServiceRequests> GetAllRequests()
        {
            List<ServiceRequests> requests = new List<ServiceRequests>();

            InOrderTraversal(root, requests);

            return requests;
        }

        /// <summary>
        /// Recursively performs an in-order traversal of the tree to collect service requests.
        /// </summary>
        /// <param name="node">The current node in the tree.</param>
        /// <param name="requests">The list to collect the service requests.</param>
        private void InOrderTraversal(TreeNode node, List<ServiceRequests> requests)
        {
            if (node != null)
            {
                InOrderTraversal(node.Left, requests);

                requests.Add(node.Request);

                InOrderTraversal(node.Right, requests);
            }
        }
    }
}
