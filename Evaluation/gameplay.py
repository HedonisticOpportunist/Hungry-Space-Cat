from wordcloud import WordCloud, STOPWORDS
import matplotlib.pyplot as plt

# create an array of adjectives
gameplay = ["fun", "playable", "challenging", "good", "mature", "fun", "unique", "good", "playable", "good", "fast-paced", "good", "responsive", "challenging", "right"]

# join the array with any empty spaces 
gameplay = " ".join(gameplay)

# set stopwords 
stopwords = set(STOPWORDS)

# set up the word cloud 
wordcloud = WordCloud(background_color ='white', stopwords = stopwords).generate(gameplay)
 
# plot the WordCloud image                       
plt.figure(figsize = (7, 7), facecolor = None)
plt.imshow(wordcloud, interpolation='bilinear')
plt.axis("off")
plt.tight_layout(pad = 0)
 
plt.show()
