using MergeSortTest;

string path = @"C:\Users\Виталий\WebsiteProjects\SSWU_VitaliiYaltukhov_NET_CAMP\HomeTask_11\task_2\input.txt";
string first = @"C:\Users\Виталий\WebsiteProjects\SSWU_VitaliiYaltukhov_NET_CAMP\HomeTask_11\task_2\first.txt";
string second = @"C:\Users\Виталий\WebsiteProjects\SSWU_VitaliiYaltukhov_NET_CAMP\HomeTask_11\task_2\second.txt";

//generate values for an input file
Generator.GenerateValues(path, 100, 1, 101);

FileMergeSort.SortArrayWith100Elements(path, first, second);
