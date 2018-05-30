from django.test import TestCase, Client
from django.core.urlresolvers import reverse
from django.contrib.staticfiles import finders
from django.conf import settings
from django.contrib.auth.models import User
from mullproject.models import Settlement, Category, Question
from mullproject.forms import CategoryForm, SettlementForm, QuestionForm
import os

class GeneralTests(TestCase):
	def test_serving_static_image_files(self):
		result = finders.find('images/background1.png')
		self.assertIsNotNone(result)

	def test_serving_css_files(self):
		result = finders.find('css/index.css')
		self.assertIsNotNone(result)

	def test_base_template_exists(self):
		path_to_base = os.path.join(settings.BASE_DIR, 'csj_project/templates') + '/mullproject/base.html'
		print (path_to_base)
		self.assertTrue(os.path.isfile(path_to_base))

class IndexTestCases(TestCase):
	def test_index_success(self):
		response = self.client.get(reverse('index'))
		self.assertEqual(response.status_code, 200)
		
	def test_index_using_template(self):
		response = self.client.get(reverse('index'))
		self.assertTemplateUsed(response, 'mullproject/index.html')

class QuizTestCases(TestCase):
	def test_quiz_success(self):
		response = self.client.get(reverse('map'))
		self.assertEqual(response.status_code, 200)
		
	def test_quiz_using_template(self):
		response = self.client.get(reverse('map'))
		self.assertTemplateUsed(response, 'mullproject/map.html')

class GameTestCases(TestCase):
	def test_game_success(self):
		response = self.client.get(reverse('game'))
		self.assertEqual(response.status_code, 200)
		
	def test_game_using_template(self):
		response = self.client.get(reverse('game'))
		self.assertTemplateUsed(response, 'mullproject/game.html')

class CategoriesTestCases(TestCase):
	def test_categories_success(self):
		response = self.client.get(reverse('categories'))
		self.assertEqual(response.status_code, 200)
		
	def test_categories_using_template(self):
		response = self.client.get(reverse('categories'))
		self.assertTemplateUsed(response, 'mullproject/categories.html')

	def test_categories_empty(self):
		response = self.client.get(reverse('categories'))
		self.assertContains(response, 'There are currently no categories present.', status_code=200)

	def test_categories_no_settlements(self):
		c = Category.objects.create(gaelic_name='gname', english_name='ename')
		response = self.client.get(reverse('settlements', kwargs={'category': c.slug}))
		self.assertContains(response, 'There are currently no settlements in this category.', status_code=200)

class AboutTestCases(TestCase):
	def test_about_success(self):
		response = self.client.get(reverse('about'))
		self.assertEqual(response.status_code, 200)
		
	def test_about_using_template(self):
		response = self.client.get(reverse('about'))
		self.assertTemplateUsed(response, 'mullproject/about.html')

class TestAdminPanel(TestCase):
	def setUp(self):
		test_admin = User.objects.create_superuser('test_admin', 'email@test.com', 'test_password')

	def test_admin_login(self):
		response = self.client.login(username='test_admin', password='test_password')
		self.assertTrue(response)

	def test_admin_pages(self):
		response = self.client.login(username='test_admin', password='test_password')

		admin_pages = [
            		"/admin/",
            		"/admin/auth/",
            		"/admin/auth/group/",
            		"/admin/auth/group/add/",
            		"/admin/auth/user/",
            		"/admin/auth/user/add/",
            		"/admin/password_change/",
			"/admin/mullproject/category/",
			"/admin/mullproject/category/add/",
			"/admin/mullproject/question/add/",
			"/admin/mullproject/settlement/",
			"/admin/mullproject/settlement/add/"
        	]
        	for page in admin_pages:
            		resp = self.client.get(page)
            		assert resp.status_code == 200
            		assert "<!DOCTYPE html" in resp.content

class TestCreateModels(TestCase):
	def test_new_settlement(self):
		s = Settlement.objects.create(headname='h', grid_ref='111111', anglicised='a', historical_forms="hf", lang_of_origin="GAELIC", original_elements="oe", interpretation="i", extent="ex", certainty="1")
		self.assertTrue(isinstance(s, Settlement))
		self.assertEqual(s.__unicode__(), s.headname + " | " + s.grid_ref)

	def test_new_category(self):
		c = Category.objects.create(gaelic_name='gname', english_name='ename')
		self.assertTrue(isinstance(c, Category))
		self.assertEqual(c.__unicode__(), c.english_name)

	def test_new_question(self):
		s = Settlement.objects.create(headname='h', grid_ref='111111', anglicised='a', historical_forms="hf", lang_of_origin="GAELIC", original_elements="oe", interpretation="i", extent="ex", certainty="1")
		q = Question.objects.create(text_english='equestion', text_gaelic='gquestion', answer=s)
		self.assertTrue(isinstance(q, Question))
		self.assertEqual(q.__unicode__(), q.text_english)

class TestForms(TestCase):
	def test_valid_category_form(self):
		data = {'gaelic_name': 'gname', 'english_name': 'ename'}
		form = CategoryForm(data=data)
		self.assertTrue(form.is_valid())

	def test_invalid_category_form(self):
		data = {'gaelic_name': 'gname', 'english_name': ''}
		form = CategoryForm(data=data)
		self.assertFalse(form.is_valid())

	def test_valid_question_form(self):
		s = Settlement.objects.create(headname='h', grid_ref='111111', anglicised='a', historical_forms="hf", lang_of_origin="GAELIC", original_elements="oe", interpretation="i", extent="ex", certainty="1")
		data = {'text_english': 'te', 'text_gaelic': 'tg', 'answer': s.headname}
		form = QuestionForm(data=data)
		self.assertTrue(form.is_valid())

	def test_invalid_question_form(self):
		s = Settlement.objects.create(headname='h', grid_ref='111111', anglicised='a', historical_forms="hf", lang_of_origin="GAELIC", original_elements="oe", interpretation="i", extent="ex", certainty="1")
		data = {'text_english': '', 'text_gaelic': 'tg', 'answer': s.headname}
		form = QuestionForm(data=data)
		self.assertFalse(form.is_valid())

	def test_valid_settlement_form(self):
		c = Category.objects.create(gaelic_name="Tuineachadh",
		english_name="Habitation")
		data={"headname":"Druim nan Taighean",
			"anglicised":"Drimnatain",
			"grid_ref":"NM697269",
			"historical_forms":"drumnatyin (1494)",
            "lang_of_origin":"Gaelic",
            "original_elements":"druim + nan + taighean",
            "interpretation":"druim nan taighean' | 'dwellings-ridge'",
            "extent":"Pennyland",
            "certainty":"4", "categories":[Category.objects.first()]
			}
		form = SettlementForm(data=data)
		self.assertTrue(form.is_valid())

	def test_invalid_settlement_form(self):
		c = Category.objects.create(gaelic_name="Tuineachadh",
		english_name="Habitation")
		data={"headname":"Druim nan Taighean",
			"anglicised":"Drimnatain",
			"grid_ref":"NM697269",
			"historical_forms":"drumnatyin (1494)",
            "lang_of_origin":"",
            "original_elements":"druim + nan + taighean",
            "interpretation":"druim nan taighean' | 'dwellings-ridge'",
            "extent":"Pennyland",
            "certainty":"4", "categories":[Category.objects.first()]
			}
		form = SettlementForm(data=data)
		self.assertFalse(form.is_valid())


class TestManagePanel(TestCase):
	def setUp(self):
		test_admin = User.objects.create_superuser('test_admin', 'email@test.com', 'test_password')

	def test_manage_pages(self):
		manage_pages = [
            		"/manage/",
			"/add_category/",
			"/add_settlement/",
			"/add_question/"
        	]
        	for page in manage_pages:
            		resp = self.client.get(page)
            		assert resp.status_code == 200
            		assert "<!DOCTYPE html" in resp.content

	def test_manage_using_template(self):
		response = self.client.get(reverse('manage'))
		self.assertTemplateUsed(response, 'mullproject/manage.html')

	def test_manage_authorised_access(self):
		self.client.login(username='test_admin', password='test_password')
		response = self.client.get(reverse('manage'))
		self.assertNotContains(response, '<div class="container" id="notAuthorisedText">', status_code=200)
		self.client.logout()
		response = self.client.get(reverse('manage'))
		self.assertContains(response, '<div class="container" id="notAuthorisedText">', status_code=200)

	def test_delete_category(self):
		c = Category.objects.create(gaelic_name='gname', english_name='ename')
		c.save()
		s = Settlement.objects.create(headname='testh', grid_ref='NM111111', anglicised='a', historical_forms="hf", lang_of_origin="GAELIC", original_elements="oe", interpretation="i", extent="ex", certainty="1")
		s.categories = [c]
		s.save()
		self.client.login(username='test_admin', password='test_password')
		response = self.client.get(reverse('delete_category', kwargs={'category': c.slug}))
		self.assertContains(response, 'cannot be deleted', status_code=200)

	def test_delete_settlement(self):
		s = Settlement.objects.create(headname='testh', grid_ref='NM111111', anglicised='a', historical_forms="hf", lang_of_origin="GAELIC", original_elements="oe", interpretation="i", extent="ex", certainty="1")
		self.client.login(username='test_admin', password='test_password')
		response = self.client.get(reverse('delete_settlement', kwargs={'settlement': s.slug}))
		self.assertContains(response, 'has been deleted.', status_code=200)

	def test_delete_question(self):
		s = Settlement.objects.create(headname='h', grid_ref='111111', anglicised='a', historical_forms="hf", lang_of_origin="GAELIC", original_elements="oe", interpretation="i", extent="ex", certainty="1")
		q = Question.objects.create(text_english='equestion', text_gaelic='gquestion', answer=s)
		self.client.login(username='test_admin', password='test_password')
		response = self.client.get(reverse('delete_question', kwargs={'question': q.id}))
		self.assertContains(response, 'has been deleted.', status_code=200)

class APITestCases(TestCase):
	def test_settlement_api_success(self):
		response = self.client.get(reverse('settlement_api'))
		self.assertEqual(response.status_code, 200)

	def test_settlement_api_content(self):
		response = self.client.get(reverse('settlement_api'))
		self.assertEqual(len(response.data), len(Settlement.objects.all()))
	
	def test_question_api_success(self):
		response = self.client.get(reverse('question_api'))
		self.assertEqual(response.status_code, 200)

	def test_question_api_content(self):
		response = self.client.get(reverse('question_api'))
		self.assertEqual(len(response.data), len(Question.objects.all()))
