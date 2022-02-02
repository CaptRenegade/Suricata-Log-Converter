***Suricata Log Converter***

Thank you for your interest in my Suricata Log Converter!
I'm not sure if this applies to stand-alone versions of Suricata IDS/IPS but
being a big fan of the pfsense router/firewall and all its features, I noticed
its implementation of Suricata has a log export feature which exports the log as
a .log text file.  This is not easy to aggregate into charts/graphs or any other
meaningful representation elements.  Therefore I wrote this little program to
convert the .log text file into a .xlsx MS Excel file.

The converter splits the lines based on what's enclosed in brackets [] and
maps those elements to predefined columns.

I hope this is useful.  Maybe one day the makers of Suricata will add a save
to MS Excel function. :)