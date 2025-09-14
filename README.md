# 📦 Base64EncodeDecode


A compact and efficient Base64 encoder/decoder implementation in C#, featuring a custom character set (A-Z, a-z, 0-9, +, /) and support for string arrays.

🚀 Features

Custom Base64 alphabet (A-Z, a-z, 0-9, _, -)

UTF-8 encoding support

Encode and decode individual strings

Encode and decode arrays of strings

Padding-aware decoding logic

🧪 Usage

Encoding a string
```
string encoded = Base64.Encode("🎁");
Console.WriteLine(encoded); // Output: 8J+OgQ==
```

Decoding a string
```
string decoded = Base64.Decode("8J+OgQ==");
Console.WriteLine(decoded); // Output: 🎁
```

Encoding an array of strings
```
var strs = new List<string> { "🎁", "Hello" };
string encoded = new Solution().Encode(strs);
Console.WriteLine(encoded); // Output: 8J+OgQ===SGVsbG8===
```

Decoding an encoded string
```
var decodedList = new Solution().Decode("8J+OgQ===SGVsbG8===");
foreach (var str in decodedList)
    Console.WriteLine(str);
```

📂 Structure

Base64.cs: Contains the Base64 encoding and decoding logic

Solution.cs: Provides array encoding/decoding utilities

🛠 Requirements

.NET 6.0 or later
