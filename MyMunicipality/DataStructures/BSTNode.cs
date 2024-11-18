using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyMunicipality.Models;

namespace MyMunicipality.DataStructures
{
    /// <summary>
    /// Represents a node in a binary tree structure specifically designed to hold service request data.
    /// </summary>
    public class TreeNode
    {
        /// <summary>
        /// The service request data associated with this node.
        /// </summary>
        public ServiceRequests Request { get; set; }

        /// <summary>
        /// The left child node in the binary tree.
        /// </summary>
        public TreeNode Left { get; set; }

        /// <summary>
        /// The right child node in the binary tree.
        /// </summary>
        public TreeNode Right { get; set; }

        /// <summary>
        /// Constructor that initializes the tree node with a service request.
        /// </summary>
        /// <param name="request">The service request to associate with this node.</param>
        public TreeNode(ServiceRequests request)
        {
            // Set the request data for this node
            Request = request;

            // Initialize the left and right children to null
            Left = null;
            Right = null;
        }
    }
}
