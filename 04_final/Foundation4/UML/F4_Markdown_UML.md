# Program 4: Polymorphism with Exercise Tracking

                +------------------+
                |     Activity     |
                +------------------+
                | - date: string   |
                | - minutes: int   |
                +------------------+
                | + get_distance(): float |
                | + get_speed(): float    |
                | + get_pace(): float     |
                | + get_summary(): str    |
                +------------------+
                    /    |    \
                    /     |     \
                    /      |      \
                /       |       \
+--------------+  +---------------+  +----------------+
|   Running    |  |   Cycling     |  |   Swimming     |
+--------------+  +---------------+  +----------------+
| - distance   |  | - speed       |  | - laps         |
+--------------+  +---------------+  +----------------+
| overrides methods from Activity (if needed)         |
+-----------------------------------------------------+