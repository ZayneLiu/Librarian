# Table of Contents <!-- omit in toc -->
- [Report](#report)
  - [Introduction](#introduction)
  - [Literature Review](#literature-review)
    - [Full-Text Search Engine](#full-text-search-engine)
      - [Inverted Index](#inverted-index)
      - [Precision and Recall](#precision-and-recall)
      - [Morphological Analysis (Stemming)](#morphological-analysis-stemming)
      - [Ranking](#ranking)
  - [References](#references)

# Report
## Introduction
## Literature Review
### Full-Text Search Engine
Full-Text search engines perform linguistic searches against text data in target document or collection of text data based on the rules of a particular language (Microsoft Docs, 2020). `Full-Text search engines consider the basic unit of Full-Text search as a token rather than a word (Melton & Buxton, 2006). Full-Text queries can include simple words and phrases or multiple forms of a word or phrase. A Full-Text query returns any documents that contain at least one match (also known as a hit). A match occurs when a target document contains all the terms specified in the Full-Text query, and meets any other search conditions, such as the distance between the matching terms. It widely used in modern technology like web search(Google Search, Bing Search, etc.), desktop search(search for local files) and even email search.
#### Inverted Index
#### Precision and Recall
#### Morphological Analysis (Stemming)
#### Ranking





In general, there is a tradeoff between "precision" and "recall". High precision means that fewer irrelevant results are presented (no false positives), while high recall means that fewer relevant results are missing (no false negatives). Using the LIKE operator gives you 100% precision with no concessions for recall. A full text search facility gives you a lot of flexibility to tune down the precision for better recall.

Most full text search implementations use an "inverted index". This is an index where the keys are individual terms, and the associated values are sets of records that contain the term. Full text search is optimized to compute the intersection, union, etc. of these record sets, and usually provides a ranking algorithm to quantify how strongly a given record matches search keywords.

The SQL LIKE operator can be extremely inefficient. If you apply it to an un-indexed column, a full scan will be used to find matches (just like any query on an un-indexed field). If the column is indexed, matching can be performed against index keys, but with far less efficiency than most index lookups. In the worst case, the LIKE pattern will have leading wildcards that require every index key to be examined. In contrast, many information retrieval systems can enable support for leading wildcards by pre-compiling suffix trees in selected fields.

Other features typical of Full-Text search are

lexical analysis or tokenization—breaking a block of unstructured text into individual words, phrases, and special tokens
morphological analysis, or stemming—collapsing variations of a given word into one index term; for example, treating "mice" and "mouse", or "electrification" and "electric" as the same word
ranking—measuring the similarity of a matching record to the query string
## References

Reiner, K. Chichao, C. Farzin, M. Ravi, K.,2006. [Searching with context | ACM Digital Library](https://dl.acm.org/doi/abs/10.1145/1135777.1135847). Accessed on July 1st, 2020. <br/>
Microsoft Docs, 2018. [Full-Text Search - SQL Server | Microsoft Docs](https://docs.microsoft.com/en-us/sql/relational-databases/search/full-text-search?view=sql-server-ver15). Accessed on July 1st, 2020.<br/>
Melton, J. Buxton, S., 2006. [Chapter 13 - What's Missing? - Querying XML | ScienceDirect](https://doi.org/10.1016/B978-155860711-8/50014-9). Accessed on July 1st, 2020.<br/>