using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Runtime.InteropServices;

namespace TestLibCPP
{
    [TestClass]
    public class TestLibIA
    {

        [DllImport("libCPP.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static IntPtr createAPI();

        [DllImport("libCPP.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static IntPtr removeAPI(IntPtr api);

        [DllImport("libCPP.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static IntPtr play_test(IntPtr api, int[] board);

        [DllImport("libCPP.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static IntPtr play_Noob(IntPtr api, int[] board, int sizeBoard, int player,int[] res);

        [DllImport("libCPP.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static IntPtr play_Starting(IntPtr api, int[] board, int sizeBoard, int player, int[] res);

        [DllImport("libCPP.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static IntPtr play_Progressive(IntPtr api, int[] board, int sizeBoard, int player, int[] res, int numTurn);

        [DllImport("libCPP.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static IntPtr play_selectionPiece(IntPtr api, int[] board, int sizeBoard, int linePiece, int columnPiece, int[] res);

        [DllImport("libCPP.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static IntPtr play_selectionBall(IntPtr api, int[] board, int sizeBoard, int player, int[] res);

        [TestMethod]
        public void R23_3_IA_LEVEL_NOOB()
        {
            int sizeBoard = 7;
            int player = 1;
            int[] board = { 1, 1, 0, 3, 0, 1, 1,
                            0, 0, 1, 0, 0, 0, 0,
                            0, 0, 0, 0, 1, 0, 0,
                            0, 0, 0, 0, 0, 0, 0,
                            0, 0, 0, 2, 0, 0, 0,
                            0, 2, 0, 0, 0, 0, 0,
                            2, 0, 4, 0, 2, 2, 2 };
            int[] res = { -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1 };
            IntPtr api = createAPI();
            play_Noob(api, board, sizeBoard, player,res);
            
            Assert.AreNotEqual(-1, res[0]);
            Assert.AreNotEqual(-1, res[1]);
            Assert.AreNotEqual(-1, res[2]);
            Assert.AreNotEqual(-1, res[3]);
            
            for (int i = 0; i < 4; i++)
            {
                Assert.AreNotEqual(-1, res[i]);
                Assert.IsTrue(res[i] >= 0);
                Assert.IsTrue(res[i] < sizeBoard);
            }


            removeAPI(api);
        }

        [TestMethod]
        public void R23_4_IA_LEVEL_STARTING()
        {
            int sizeBoard = 7;
            int player = 1;
            int[] board = { 1, 1, 0, 3, 0, 1, 1,
                            0, 0, 1, 0, 0, 0, 0,
                            0, 0, 0, 0, 1, 0, 0,
                            0, 0, 0, 0, 0, 0, 0,
                            0, 0, 0, 2, 0, 0, 0,
                            0, 2, 0, 0, 0, 0, 0,
                            2, 0, 4, 0, 2, 2, 2 };
            int[] res = { -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1 };
            IntPtr api = createAPI();
            play_Starting(api, board, sizeBoard, player, res);

            Assert.AreEqual(2, res[0]);
            Assert.AreEqual(4, res[1]);
            Assert.AreEqual(3, res[2]);
            Assert.AreEqual(4, res[3]);
            Assert.AreEqual(3, res[4]);
            Assert.AreEqual(4, res[5]);
            Assert.AreEqual(3, res[6]);
            Assert.AreEqual(3, res[7]);
            Assert.AreEqual(-1, res[8]);
            Assert.AreEqual(-1, res[9]);
            Assert.AreEqual(-1, res[10]);
            Assert.AreEqual(-1, res[11]);



            removeAPI(api);
        }


        [TestMethod]
        public void R23_5_IA_LEVEL_PROGRESSIVE_TURN_INF_10()
        {
            int sizeBoard = 7;
            int player = 1;
            int[] board = { 1, 1, 0, 3, 0, 1, 1,
                            0, 0, 1, 0, 0, 0, 0,
                            0, 0, 0, 0, 1, 0, 0,
                            0, 0, 0, 0, 0, 0, 0,
                            0, 0, 0, 2, 0, 0, 0,
                            0, 2, 0, 0, 0, 0, 0,
                            2, 0, 4, 0, 2, 2, 2 };
            int[] res = { -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1 };
            IntPtr api = createAPI();
            play_Progressive(api, board, sizeBoard, player, res,4);

            Assert.AreNotEqual(-1, res[0]);
            Assert.AreNotEqual(-1, res[1]);
            Assert.AreNotEqual(-1, res[2]);
            Assert.AreNotEqual(-1, res[3]);

            for (int i = 0; i < 4; i++)
            {
                Assert.AreNotEqual(-1, res[i]);
                Assert.IsTrue(res[i] >= 0);
                Assert.IsTrue(res[i] < sizeBoard);
            }


            removeAPI(api);
        }

        [TestMethod]
        public void R23_5_IA_LEVEL_PROGRESSIVE_TURN_SUP_10()
        {
            int sizeBoard = 7;
            int player = 1;
            int[] board = { 1, 1, 0, 3, 0, 1, 1,
                            0, 0, 1, 0, 0, 0, 0,
                            0, 0, 0, 0, 1, 0, 0,
                            0, 0, 0, 0, 0, 0, 0,
                            0, 0, 0, 2, 0, 0, 0,
                            0, 2, 0, 0, 0, 0, 0,
                            2, 0, 4, 0, 2, 2, 2 };
            int[] res = { -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1 };
            IntPtr api = createAPI();
            play_Progressive(api, board, sizeBoard, player, res, 15);

            Assert.AreEqual(2, res[0]);
            Assert.AreEqual(4, res[1]);
            Assert.AreEqual(3, res[2]);
            Assert.AreEqual(4, res[3]);
            Assert.AreEqual(3, res[4]);
            Assert.AreEqual(4, res[5]);
            Assert.AreEqual(3, res[6]);
            Assert.AreEqual(3, res[7]);
            Assert.AreEqual(-1, res[8]);
            Assert.AreEqual(-1, res[9]);
            Assert.AreEqual(-1, res[10]);
            Assert.AreEqual(-1, res[11]);



            removeAPI(api);
        }

        [TestMethod]
        public void TestSelectionPiece()
        {
            int sizeBoard = 7;
            int player = 1;
            int[] board = { 1, 1, 0, 3, 0, 1, 1,
                            0, 0, 1, 0, 0, 0, 0,
                            0, 0, 0, 0, 1, 0, 0,
                            0, 0, 0, 0, 0, 0, 0,
                            0, 0, 0, 2, 0, 0, 0,
                            0, 2, 0, 0, 0, 0, 0,
                            2, 0, 4, 0, 2, 2, 2 };
            int[] res = { -1, -1, -1, -1, -1, -1, -1, -1 };
            IntPtr api = createAPI();

            play_selectionPiece(api, board, sizeBoard, 1, 2, res);

            Assert.AreEqual(res[0], 0);
            Assert.AreEqual(res[1], 2);
            Assert.AreEqual(res[2], 1);
            Assert.AreEqual(res[3], 1);
            Assert.AreEqual(res[4], 2);
            Assert.AreEqual(res[5], 2);
            Assert.AreEqual(res[6], 1);
            Assert.AreEqual(res[7], 3);
  




            removeAPI(api);
        }

        [TestMethod]
        public void TestSelectionBall()
        {
            int sizeBoard = 7;
            int player = 1;
            int[] board = { 1, 1, 0, 3, 0, 1, 1,
                            0, 0, 1, 0, 0, 0, 0,
                            0, 0, 0, 0, 1, 0, 0,
                            0, 0, 0, 0, 0, 0, 0,
                            0, 0, 0, 2, 0, 0, 0,
                            0, 2, 0, 0, 0, 0, 0,
                            2, 0, 4, 0, 2, 2, 2 };
            int[] res = { -1, -1, -1, -1, -1, -1, -1, -1,-1,-1,-1,-1,-1,-1,-1,-1 };
            IntPtr api = createAPI();

            play_selectionBall(api, board, sizeBoard,player, res);

            Assert.AreEqual(res[0], 0);
            Assert.AreEqual(res[1], 1);
            Assert.AreEqual(res[2], 0);
            Assert.AreEqual(res[3], 5);
            Assert.AreEqual(res[4], 1);
            Assert.AreEqual(res[5], 2);
            Assert.AreEqual(res[6], -1);
            Assert.AreEqual(res[7], -1);
            Assert.AreEqual(res[8], -1);
            Assert.AreEqual(res[9], -1);
            Assert.AreEqual(res[10], -1);
            Assert.AreEqual(res[11], -1);
            Assert.AreEqual(res[12], -1);
            Assert.AreEqual(res[13], -1);
            Assert.AreEqual(res[14], -1);
            Assert.AreEqual(res[15], -1);



            removeAPI(api);
        }
    }
}
