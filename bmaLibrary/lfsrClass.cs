using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bmaLibrary
{
    public class LFSR
    {
        public int Length { get; private set; }
        public Polynomial Feedback { get; private set; }
        public bool[] State { get; private set; }

        public LFSR(int length, Polynomial feedback)
        {
            if (length <= 0 || length < feedback.Degree)
            {
                throw new ArgumentException("Invalid length or feedback polynomial");
            }

            Length = length;
            Feedback = feedback;

            State = new bool[length];
            Array.Fill(State, false);
        }

        public LFSR(int length, Polynomial feedback, bool[] seq)
        {
            if (length <= 0 || length < feedback.Degree)
            {
                throw new ArgumentException("Invalid length or feedback polynomial");
            }

            Length = length;
            Feedback = feedback;
            State = seq;
        }

        public LFSR(string state, Polynomial feedback)
        {
            if (state.Length <= 0 || state.Length < feedback.Degree)
            {
                throw new ArgumentException("Invalid length or feedback polynomial");
            }

            Length = state.Length;
            Feedback = new Polynomial(feedback.Coefficients, state);

            State = new bool[state.Length];

            for (int i = 0; i < state.Length; i++)
            {
                switch (state[i])
                {
                    case '1':
                        State[state.Length - i - 1] = true;
                        break;
                    case '0':
                        State[state.Length - i - 1] = false;
                        break;
                    default:
                        throw new ArgumentException("Invalid state of register");
                }
            }
        }

        public bool Shift()
        {
            bool outputBit = State[Length - 1];
            bool inputBit = State[Feedback.Degree - 1];
                         
            for (int i = 1; i < Feedback.Degree; i++)
            {
                if (Feedback.Coefficients[i])
                {
                    inputBit ^= State[i - 1];
                }
            }

            for (int i = Length - 1; i >= 1; i--)
            {
                State[i] = State[i - 1];
            }

            State[0] = inputBit;

            return outputBit;
        }

        public bool[] Generate(int count)
        {
            if (count <= 0)
            {
                throw new ArgumentException("Invalid count");
            }

            bool[] outputBits = new bool[count];

            for (int i = 0; i < count; i++)
            {
                outputBits[i] = Shift();
            }

            return outputBits;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Length: {Length}");
            sb.AppendLine($"Feedback: {Feedback}");

            sb.Append("State: ");
            foreach (bool bit in State)
            {
                sb.Append(bit ? "1" : "0");
            }

            return sb.ToString();
        }
    }


}
