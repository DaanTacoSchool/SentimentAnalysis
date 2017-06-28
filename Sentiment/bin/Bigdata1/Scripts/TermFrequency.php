<?php

if(!isset($argv[1]))
{
    exit('Usage: TermFrequency.php <tweets.txt>');
}
$v1 = $argv[1];
$tweets_file = file_get_contents("./Userfiles/$v1");

$tweets = json_decode($tweets_file, true);
$tweets = $tweets['statuses'];

$term_occurrences = [];
$total_occurrences = 0;
foreach($tweets as $tweet)
{
    //Delimit
    $tweet_words = preg_split('/((^\p{P}+)|(\p{P}*\s+\p{P}*)|(\p{P}+$))/', $tweet['text'], -1, PREG_SPLIT_NO_EMPTY);
    foreach($tweet_words as $word)
    {
        if(!array_key_exists($word, $term_occurrences))
        {
            $term_occurrences[$word] = 0;
        }
        $term_occurrences[$word] += 1;
        $total_occurrences += 1;
    }
}

//divide amount of times a term is mentioned by total amount of terms mentioned
foreach($term_occurrences as $term => $frequency)
{
    $term_occurrences[$term] = $frequency / $total_occurrences;
}

//sort terms by frequency desc
arsort($term_occurrences, SORT_NUMERIC);

$output = fopen('./Userfiles/termfrequency.txt', 'w+');
foreach($term_occurrences as $term => $frequency)
{
    fwrite($output, "{$term} {$frequency}\r\n");
}
fclose($output);