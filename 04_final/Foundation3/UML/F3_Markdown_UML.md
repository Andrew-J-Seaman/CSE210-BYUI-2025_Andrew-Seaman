# Program 3: Inheritance with Event Planning

                          +-------------------+
                          |       Event       |
                          +-------------------+
                          | - title: string    |
                          | - description: str |
                          | - date: string     |
                          | - time: string     |
                          | - address: Address |
                          +-------------------+
                          | + get_standard_details(): str |
                          | + get_short_description(): str|
                          +-------------------+
                                   / | \
                                  /  |  \
                                 /   |   \
                                /    |    \
                               /     |     \
        +------------+  +---------------+  +---------------------+
        |  Lecture   |  |   Reception   |  |  OutdoorGathering   |
        +------------+  +---------------+  +---------------------+
        | - speaker  |  | - rsvp_email  |  | - weather_forecast  |
        | - capacity |  +---------------+  +---------------------+
        | + get_full_details(): str    (same method in each)     |
        +------------+  +---------------+  +---------------------+

+-------------------+
|     Address       |
+-------------------+
| - street: string  |
| - city: string    |
| - state: string   |
| - country: string |
+-------------------+