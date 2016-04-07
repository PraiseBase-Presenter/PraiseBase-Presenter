using System.Reflection;
using System.Resources;
using System.Runtime.InteropServices;

// General Information about an assembly is controlled through the following
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
[assembly: AssemblyTitle("PraiseBase Presenter")]
[assembly: AssemblyDescription("Projects song lyrics and images using multiple screens")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("PraiseBase.org")]
[assembly: AssemblyProduct("PraiseBase Presenter")]
[assembly: AssemblyCopyright("Copyright © PraiseBase.org 2008")]
[assembly: AssemblyTrademark("PraiseBase")]
[assembly: AssemblyCulture("")]

// Setting ComVisible to false makes the types in this assembly not visible
// to COM components.  If you need to access a type in this assembly from
// COM, set the ComVisible attribute to true on that type.
[assembly: ComVisible(true)]

// The following GUID is for the ID of the typelib if this project is exposed to COM
[assembly: Guid("2a6e2e1d-bedd-4b2f-aa53-7716eca2499e")]

// Version information for an assembly consists of the following four values:
//
//      Major Version
//      Minor Version
//      Build Number
//      Revision
//
// You can specify all the values or you can default the Build and Revision Numbers
// by using the '*' as shown below:
// [assembly: AssemblyVersion("1.0.*")]
[assembly: AssemblyVersion("1.2.6")]
[assembly: AssemblyFileVersion("1.2.6")]
[assembly: NeutralResourcesLanguageAttribute("de-CH")]
[assembly: System.Runtime.CompilerServices.InternalsVisibleTo("Test")]
[assembly: log4net.Config.XmlConfigurator(ConfigFile = "log.config", Watch = true)]
