﻿# Important Takeaways
1. The configuration file ‘appsettings.json’ was not found and is not optional
	Answer: Right-click on the appsettings.json file -> click on Properties
		-> Check the property Copy to Output Directory. 
		-> It might be Do not copy. Change this to "Copy always" or "Copy if newer".


2. A connection was successfully established with the server, but then an error occurred during the login process. 
	(provider: SSL Provider, error: 0 - The certificate chain was issued by an authority that is not trusted.)

	Answer (not recommended): add the following in the connection string TrustServerCertificate=True
	E.g. Server=MyServerName;Database=MyDbName;Trusted_Connection=SSPI;Encrypt=false;TrustServerCertificate=true

