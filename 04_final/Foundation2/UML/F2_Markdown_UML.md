# Program 2: Encapsulation with Online Ordering

+------------------+                 +------------------+           +-----------------+                    +-------------------+
|      Order       |                 |     Product      |           |    Customer     |                    |     Address       |
+------------------+                 +------------------+           +-----------------+                    +-------------------+
| - products: List<Product>         | - name: string    |           | - name: string  |                    | - street: string  |
| - customer: Customer              | - product_id: str |           | - address: Addr |                    | - city: string    |
+-----------------------------+     | - price: float   |            +-----------------+                    | - state: string   |
| + get_total_cost(): float         | - quantity: int   |           | + lives_in_usa():bool                | - country: string |
| + get_packing_label(): str        +------------------+            +----------------------------+         | + is_usa(): bool  |
| + get_shipping_label(): str                                                                              | + to_string(): str |
+-----------------------------+                                                                            +-------------------+