from mullproject.models import Settlement, Question
from rest_framework import serializers

# used to pass settlement info over to Unity
class SettlementSerializer(serializers.ModelSerializer):
    class Meta:
        model = Settlement
        fields = ('headname', 'extent', 'eastings', 'northings', 'slug')

# used to pass question info over to Unity
class QuestionSerializer(serializers.ModelSerializer):
	class Meta:
		model = Question
		fields = ('text_english', 'text_gaelic', 'answer', 'id')
