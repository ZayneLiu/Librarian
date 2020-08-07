### Report can be found [here](./Report.md)
# A cross-platform full-text search engine for local filesystem

An alternative to Apache Tika for C# ecosystem written in `.NET Core`, `C#`.

# Project Structure
- Custodian API
  - Indexing Module
    - OCR
  - Searching Module
    - Semantic search
- Custodian Web API (REST API)
- Librarian
  - UI

# Progress
|  Icon   | <input type="checkbox" disabled /> | <input type="checkbox" disabled checked /> | :construction: |
| :-----: | :--------------------------------: | :----------------------------------------: | :------------: |
| Meaning |               Planed               |                    Done                    |      WIP       |

- API
  - [x] 64-bit multi-platform support.
  - [x] Indexing.
  - [x] Searching.
  - [ ] Semantic Search. !!!
  - [x] Web API + API Documentation.

- File type support
  - [x] Microsoft Office 2007+ documents support.
    - [x] `.docx`, `.docm` | Word 2007+ documents.
    - [x] `.pptx`, `.pptm` | PowerPoint 2007+ documents. :warning:
    - [x] `.xlsx`, `.xlsm` | Excel 2007+ documents. :warning:
  - [ ] Plain-text documents.
    - [x] `.txt` | Text documents.
    - [ ] `.md` | Markdown documents. :construction:
    - [ ] `.rtf` | Rich text format documents.
  - [ ] `.pdf` | PDF documents.
    - [x] Text-based PDF.
    - [ ] Image-only PDF. :construction:
  - [ ] `.epub`, `.mobi`
- Testing

  |        Icon        |                    Meaning                     |
  | :----------------: | :--------------------------------------------: |
  | :white_check_mark: |                  Fully Tested                  |
  | :heavy_check_mark: | Partially Tested<br/>( Basic functionalities ) |


  | File Type        |   Testing Status   |
  | :--------------- | :----------------: |
  | `.txt`           | :white_check_mark: |
  | `.docx`, `.docm` | :white_check_mark: |
  | `.pptx`, `.pptm` | :heavy_check_mark: |
  | `.xlsx`, `.xlsm` | :heavy_check_mark: |
  | `.pdf`           | :heavy_check_mark: |




# Notes
- ~ Abandon Electron for Node.js API~
- ~Adopting C# + Xamarin.Mac due to better performance (benchmark)~
- Focus on CLI & API.
- Use nw.js + vue.js just for the demonstration of the work flow.
- Go through Apache Tika's source code to find a solution for ooxml parsing.
- A potential C# text extraction framework (Tika C# alternative).




