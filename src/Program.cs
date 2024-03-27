using System.Management;

namespace SerialPortInfo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GetPortInformation();
        }


        public static string GetPortInformation()
        {
            ManagementClass processClass = new ManagementClass("Win32_PnPEntity");
            ManagementObjectCollection Ports = processClass.GetInstances();
            foreach (ManagementObject property in Ports)
            {
                var name = property.GetPropertyValue("Name");
                if (name != null && name.ToString().Contains("(COM"))
                {
                    var portInfo = new SerialPortManagementObject(property);

                    Console.WriteLine("Port Name:      " + name);
                    Console.WriteLine("Description:    " + portInfo.Description);
                    Console.WriteLine("Manufacturer:   " + portInfo.Manufacturer);
                    Console.WriteLine("Device ID:      " + portInfo.DeviceID);
                }
            }
            return string.Empty;
        }
    }
}
