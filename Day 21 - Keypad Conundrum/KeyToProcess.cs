using AdventLibrary;

namespace Day_21___Keypad_Conundrum
{
    internal class KeyToProcess(char input, int deviceIndex, Position padPosition, long count)
    {
        public char Input { get; set; } = input;
        public int DeviceIndex { get; set; } = deviceIndex;
        public Position PadInputIsOn { get; set; } = padPosition;
        public long Count { get; set; } = count;

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
