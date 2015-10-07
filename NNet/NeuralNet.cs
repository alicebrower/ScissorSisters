using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NNet {
    public class NeuralNet {
        static readonly int MAX_EPOCHS = 1500;
        static readonly int DESIRED_ACCURACY = 90;
        static readonly double LEARNING_RATE = 0.001;
        static readonly double MOMENTUM = 0.9;

        bool useBatch;
        double[] inputNeurons, hiddenNeurons, outputNeurons,
            hiddenErrorGradients, outputErrorGradients;
        double[,] wInputHidden, wHiddenOutput, deltaInputHidden, deltaHiddenOutput;

        public NeuralNet(int inC, int hiddenC, int outC) {
            //Init, populate, and set bias neuron
            inputNeurons = new double[inC + 1];
            for (int i = 0; i < inputNeurons.Length; i++) {
                inputNeurons[i] = 0;
            }
            inputNeurons[inC] = -1;

            hiddenNeurons = new double[hiddenC + 1];
            for (int i = 0; i < hiddenNeurons.Length; i++) {
                hiddenNeurons[i] = 0;
            }
            hiddenNeurons[inC] = -1;

            outputNeurons = new double[outC + 1];
            for (int i = 0; i < outputNeurons.Length; i++) {
                outputNeurons[i] = 0;
            }
            outputNeurons[inC] = -1;

            //Create weight lists (include bias neuron weights)
            wInputHidden = new double[inC + 1, hiddenC];
            for(int i = 0; i <= inC; i++) {
                for(int j = 0; j < hiddenC; j++) {
                    wInputHidden[i, j] = 0;
                }
            }

            wHiddenOutput = new double[hiddenC+ 1, outC];
            for (int i = 0; i <= hiddenC; i++) {
                for (int j = 0; j < outC; j++) {
                    wHiddenOutput[i, j] = 0;
                }
            }

            //Create delta lists
            deltaInputHidden = new double[inC + 1, hiddenC];
            for (int i = 0; i <= inC; i++) {
                for (int j = 0; j < hiddenC; j++) {
                    deltaInputHidden[i, j] = 0;
                }
            }

            deltaHiddenOutput = new double[hiddenC + 1, outC];
            for (int i = 0; i <= inC; i++) {
                for (int j = 0; j < hiddenC; j++) {
                    wInputHidden[i, j] = 0;
                }
            }

            //Create error gradient storage
            hiddenErrorGradients = new double[hiddenC + 1];
            for (int i = 0; i <= hiddenC; i++) {
                hiddenErrorGradients[i] = 0;
            }

            outputErrorGradients = new double[outC + 1];
            for (int i = 0; i <= hiddenC; i++) {
                outputErrorGradients[i] = 0;
            }

            //InitializeWeights();
            useBatch = false;
        }
    }
}
