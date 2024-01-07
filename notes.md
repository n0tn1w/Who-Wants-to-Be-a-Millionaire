## Checks in the XML schema

- Added check for 0 to 100 for percents. Since it is an  attribute and not an element it works with a custom type.
- Added check for sum of percents. Only the sum is not enough since there can be a negative number. The check works only in version 1.1 XSD. The parser was used from a Cool python library.
- Added a unique identifier to the question. It is created via Key and not ID because ID does not support only integers as ID, it must start with a letter.
- Difficulty is Enum -> Easy, Medium, Hard
- Count of Correct answers per question = 1
- Count of 50/50 answers per question = 2
- Length of Answer, CallAFriendText, QuestionDescription are 50, 100, 200 respectively.
- New tricky validation to check if correct answer is among the 50/50 answers
- Note that most of these are impossible with DTD.
- Also note that the schema may not work on most free online tools, because they use an outdated XML schema version and do not support 1.1.