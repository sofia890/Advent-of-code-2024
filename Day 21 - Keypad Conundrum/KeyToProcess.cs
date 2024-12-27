using AdventLibrary;

namespace Day_21___Keypad_Conundrum
{
    internal class KeyToProcess
    {
        public char Input { get; set; }
        public int DeviceIndex { get; set; }
        public Position PadInputIsOn { get; set; }
        public long Count { get; set; }

        public KeyToProcess(char input, int deviceIndex, Position padPosition, long count)
        {
            Input = input;
            DeviceIndex = deviceIndex;
            PadInputIsOn = padPosition;
            Count = count;
        }
        public override string ToString()
        {
            return $"{{ Input: {Input}, DeviceIndex: {DeviceIndex}, PadPosition: {PadInputIsOn}, Count: {Count} }}";
        }
        public (char input, Position padInputIsOn, int deviceIndex) GetIdentity()
        {
            return (Input, PadInputIsOn, DeviceIndex);
        }
    }
}
