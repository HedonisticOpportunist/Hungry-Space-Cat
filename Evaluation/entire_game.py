from wordcloud import WordCloud, STOPWORDS
import matplotlib.pyplot as plt

# create an array of adjectives
words = ["lovely", "good", "cartoony", "nice", "cute", "great", "nice", "nice", "accessible", "fun", "playable", "challenging", "good", "mature", "fun", 
"alright", "unique", "good", "playable", "good", "fast-paced", "good", "responsive", "challenging", "right", "fine", "good", "good"]

# join the array with any empty spaces 
words = " ".join(words)
# print(words)

# set stopwords 
stopwords = set(STOPWORDS)

# set up the word cloud 
wordcloud = WordCloud(background_color ='beige', stopwords = stopwords).generate(words)
 
# plot the word cloud image                       
plt.figure(figsize = (8, 8), facecolor = None)
plt.imshow(wordcloud, interpolation='bilinear')
plt.axis("off")
plt.tight_layout(pad = 0)
 
plt.show()
