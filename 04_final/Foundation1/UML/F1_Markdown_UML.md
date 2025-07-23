# Program 1: Abstraction with YouTube Videos

+-------------+             +------------+
|  Program    |             |   Data     |
+-------------+             +------------+
| - x         |             | - _videos: List<Video>   |
|             |             | - _comments: List<Comment> |
| + Main(): void            +--------------------------+
|                           | + Data()                 |
|                           | + GetVideos(): List<Video>   |
|                           | + GetComments(): List<Comment> |
+-------------+             +------------+
       |
       v
+------------------------------+
|           Video              |
+------------------------------+
| - _title: string             |
| - _author: string            |
| - _length: int               |
| - _comments: List<Comment>   |
+------------------------------+
| + Video(title, author,       |
|         length, comments):   |
|         void                 |
| + GetCommentCount(): int     |
| + DisplayInfo(): void        |
+------------------------------+
       |
       v
+------------------------+
|       Comment          |
+------------------------+
| - _commenter: string   |
| - _text: string        |
+------------------------+
| + Comment(commenter,   |
|           text): void  |
+------------------------+