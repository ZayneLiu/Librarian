### Report can be found at [here](./Report.md)
# A Cross-platform Full-text Search Engine for Local Filesystem


# Project Structure
 - Custodian
   - Indexing Module
   - Searching Module
   <!-- -  -->
- Librarian
  - UI

# Notes
- ~Abandon Electron for Node.js API~
- ~Adopting C# + Xamarin.Mac due to better performance (benchmark)~
- dedicated on CLI & API.
- use nw.js + vue.js just for the demonstration of the work flow.
- Gonna read through Apache Tika's source code to find a solution for ooxml parsing.
- a potential C# text extraction freamwork.



## OOXML workflow design
if docx ->

unzip in memory ->

get document.xml ->

parse document.xml ->

ignore elements with webHidden attribute (mostly, that would be in the TOC part) ->

extract words along the above ignoring process ->

TBC...


