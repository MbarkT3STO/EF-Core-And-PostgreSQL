using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models;

public class CreateAuthorModel
{
	public string Name { get; set; }
	
	public string Facebook { get; set; }
	public string Twitter { get; set; }
	public string Instagram { get; set; }
	public string LinkedIn { get; set; }
	public string[]? Nicknames { get; set; }	
}
