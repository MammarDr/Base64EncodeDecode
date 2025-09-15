# 📦 Base64EncodeDecode


A compact and efficient Base64 encoder/decoder implementation in C#, featuring a custom character set (A-Z, a-z, 0-9, +, /) and support for string arrays.

🚀 Features

Custom Base64 alphabet (A-Z, a-z, 0-9, _, -)

UTF-8 encoding support

Encode and decode individual strings

Encode and decode arrays of strings

Padding-aware decoding logic

🧪 Usage

Encoding & Decoding a string
```
string encoded = Base64.Encode("🎁"); // Output: 8J+OgQ==
string decoded = Base64.Decode(encoded); // Output: 🎁
```


Encoding & Decoding an array of strings
```
var strs = new List<string> { "🎁", "Hello" };
string encoded = Base64.MultiString.Encode(strs); // Output: 8J+OgQ===SGVsbG8===

var decodedList = Base64.MultiString.Decode(encoded); // Output: { "🎁", "Hello" }
```

📂 Structure

Base64.cs: Contains the Base64 encoding and decoding logic

Console.cs: Provides interface(Command-Line) to use the algorithm.

🛠 Requirements

.NET 6.0 or later
