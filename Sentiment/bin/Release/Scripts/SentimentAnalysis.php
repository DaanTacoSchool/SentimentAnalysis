<?php

if(!isset($argv[1]) || !isset($argv[2]))
{
    exit('Usage: SentimentAnalysis.php <SentimentScore.txt> <tweets.txt>');
}
$v1 = $argv[1];
$v2=$argv[2];
$sentiments_file = fopen("./Userfiles/$v1", 'r');
$tweets_file = file_get_contents("./Userfiles/$v2");

//$sentiments_file = fopen($argv[1], 'r');
//$tweets_file = file_get_contents($argv[2]);

$sentiments = [];

while(($line = fgets($sentiments_file)) !== false)
{
    $sentiment = explode("\t", $line);
    $sentiments[$sentiment[0]] = (int)$sentiment[1];
}

fclose($sentiments_file);

$tweets = json_decode($tweets_file, true);

$output_file = fopen('./Userfiles/tweetscores.txt', 'w+');
$cntr =0;
//note: this will filter out any tweets that do not have text. think of tweets like pictures and videos only. these will not be processed and wont get a score.
foreach($tweets['statuses'] as $tweet)
{
    $score = 0;
	$cntr+=1;
    //Delimit - should i check for illigal chars? ie. quotes or escapechars which could mess with the code.
	//edit: dont check, just retrieve new batch of tweets and re-run program. 
	//Note to self: try again status/ability in c# shell
    $tweet_words = preg_split('/((^\p{P}+)|(\p{P}*\s+\p{P}*)|(\p{P}+$))/', $tweet['text'], -1, PREG_SPLIT_NO_EMPTY);
    foreach($tweet_words as $word)
    {
        if(array_key_exists($word, $sentiments))
        {
            $score += $sentiments[$word];
        }
    }
    fwrite($output_file, $score."\r\n");
}
$dbg ="debug info; amount of tweets processed:".$cntr;
echo $dbg;
 fwrite($output_file, $dbg);
fclose($output_file);
/*
//doesnt work the way it is supposed to...
$file = 'tweetscores.txt';
if ($file!=NULL) {
    header('Content-Description: File Transfer');
    header('Content-Type: application/octet-stream');
    header('Content-Disposition: attachment; filename="'.basename($file).'"');
    header('Expires: 0');
    header('Cache-Control: must-revalidate');
    header('Pragma: public');
    header('Content-Length: ' . filesize($file));
    readfile($file);
    exit;
}*/

echo "\r\nTweet scores successfully written to tweetscores.txt.";