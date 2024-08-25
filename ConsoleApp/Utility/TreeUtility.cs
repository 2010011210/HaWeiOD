using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Utility
{
    // 二叉树
    public  class TreeUtility
    {
        // 1.先序遍历
        public List<int> preorderTraversal(TreeNode root)
        {
            //添加遍历结果的数组
            List<int> list = new List<int>(); ;
            //递归前序遍历
            preorder(list, root);
            //返回的结果
            // int[] res = new int[list.Count];
            // for(int i = 0; i < list.Count; i++)
            //     res[i] = list[i];
            return list;
        }

        public void preorder(List<int> list, TreeNode root)
        {
            //遇到空节点则返回
            if (root == null)
                return;
            //先遍历根节点
            list.Add(root.val);
            //再去左子树
            preorder(list, root.left);
            //最后去右子树
            preorder(list, root.right);
        }

        // 2.后序遍历
        //public void postorder(List<Integer> list, TreeNode root)
        //{
        //    //遇到空节点则返回
        //    if (root == null)
        //        return;
        //    //先去左子树
        //    postorder(list, root.left);
        //    //再去右子树
        //    postorder(list, root.right);
        //    //最后访问根节点
        //    list.add(root.val);
        //}

        //public int[] postorderTraversal(TreeNode root)
        //{
        //    //添加遍历结果的数组
        //    List<Integer> list = new ArrayList();
        //    //递归后序遍历
        //    postorder(list, root);
        //    //返回的结果
        //    int[] res = new int[list.size()];
        //    for (int i = 0; i < list.size(); i++)
        //        res[i] = list.get(i);
        //    return res;
        //}

        // 3.中序遍历
        //public class Solution
        //{
        //    public void inorder(List<Integer> list, TreeNode root)
        //    {
        //        //遇到空节点则返回
        //        if (root == null)
        //            return;
        //        //先去左子树
        //        inorder(list, root.left);
        //        //再访问根节点
        //        list.add(root.val);
        //        //最后去右子树
        //        inorder(list, root.right);
        //    }

        //    public int[] inorderTraversal(TreeNode root)
        //    {
        //        //添加遍历结果的数组
        //        List<Integer> list = new ArrayList();
        //        //递归中序遍历
        //        inorder(list, root);
        //        //返回的结果
        //        int[] res = new int[list.size()];
        //        for (int i = 0; i < list.size(); i++)
        //            res[i] = list.get(i);
        //        return res;
        //    }
        //}


        //.2. 二叉树的层级
        //public int maxDepth(TreeNode root)
        //{
        //    if (root == null)
        //        return 0;
        //    // 队列，每次while循环保存当前层的所有结点
        //    Queue<TreeNode> queue = new LinkedList<TreeNode>();
        //    int res = 0;
        //    queue.add(root);
        //    // 遍历每一层
        //    while (!queue.isEmpty())
        //    {
        //        int size = queue.size();
        //        // 遍历当前层每个结点
        //        for (int i = 0; i < size; i++)
        //        {
        //            TreeNode node = queue.poll();
        //            if (node.left != null)
        //                queue.add(node.left);
        //            if (node.right != null)
        //                queue.add(node.right);
        //        }
        //        // 记录层数
        //        res++;
        //    }
        //    return res;
        //}


    }

    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;

        public TreeNode(int x)
        {
            val = x;
        }
    }


}
