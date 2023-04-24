//Vitalii	Yaltukhov 		90	20	0	90	90	95	98	102,6
Console.WriteLine("Hello, World!");

var trees = new List<Tree>();
var trees1 = new List<Tree>();
trees1.Add(new Tree(1, 1));
trees1.Add(new Tree(2, 4));
trees1.Add(new Tree(2, 2));
trees1.Add(new Tree(5, 3));
trees1.Add(new Tree(4, 1));
var tr1 = new Fence(trees1);
var res1 = tr1.AddFence(trees1, trees1.Count);
Console.WriteLine("Result: " + tr1.LengthOfTheFence(res1));
Console.WriteLine();
