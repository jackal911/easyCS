// See https://aka.ms/new-console-template for more information

using Microsoft.ML;
using Microsoft.ML.Data;
using static Microsoft.ML.DataOperationsCatalog;
string _dataPath = Path.Combine(Environment.CurrentDirectory, "Data", "yelp_labelled.txt");

MLContext mlContext = new MLContext();
TrainTestData splitDataView = LoadData(mlContext);
ITransformer model = BuildAndTrainModel(mlContext, splitDataView.TrainSet);


TrainTestData LoadData(MLContext mlContext)
{
    IDataView dataView = mlContext.Data.LoadFromTextFile<SentimentData>(_dataPath, hasHeader: false);
    TrainTestData splitDataView = mlContext.Data.TrainTestSplit(dataView, testFraction: 0.2);
    return splitDataView;
}

ITransformer BuildAndTrainModel(MLContext mlContext, IDataView splitTrainSet)
{
    var estimator = mlContext.Transforms.Text.FeaturizeText(outputColumnName: "Features", inputColumnName: nameof(SentimentData.SentimentText))
    .Append(mlContext.BinaryClassification.Trainers.SdcaLogisticRegression(labelColumnName: "Label", featureColumnName: "Features"));
    Console.WriteLine("=============== Create and Train the Model ===============");
    var model = estimator.Fit(splitTrainSet);
    Console.WriteLine("=============== End of training ===============");
    Console.WriteLine();
    return model;
}

void Evaluate()