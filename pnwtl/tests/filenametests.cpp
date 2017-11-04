#include "stdafx.h"

#include <boost/test/unit_test.hpp>

#include "../filename.h"

/*
Workaround to make stuff compile
*/
namespace boost {
	namespace test_tools {
		namespace tt_detail {

			assertion_result
				equal_impl(wchar_t const* left, wchar_t const* right)
			{
				return (left && right) ? std::wcscmp(left, right) == 0 : (left == right);
			}
		}
	}
}

BOOST_AUTO_TEST_SUITE( filename_tests );

BOOST_AUTO_TEST_CASE( get_relative_path_simple )
{
	CFileName fn(L"c:\\test\\test2\\test3.txt");
	
	BOOST_REQUIRE_EQUAL(L"test3.txt", fn.GetRelativePath(L"c:\\test\\test2\\").c_str());
}

BOOST_AUTO_TEST_CASE( get_relative_path_no_trailing_slash )
{
	CFileName fn(L"c:\\test\\test2\\test3.txt");
	
	BOOST_REQUIRE_EQUAL(L"test3.txt", fn.GetRelativePath(L"c:\\test\\test2").c_str());
}

BOOST_AUTO_TEST_CASE( get_relative_path_subfolder )
{
	CFileName fn(L"c:\\test\\test2\\test3\\test4.txt");
	
	BOOST_REQUIRE_EQUAL(L"test3\\test4.txt", fn.GetRelativePath(L"c:\\test\\test2\\").c_str());
}

BOOST_AUTO_TEST_CASE( is_relative_path_with_drive )
{
	CFileName fn(L"c:\\test\\test2\\test3\\test4.txt");
	
	BOOST_REQUIRE_EQUAL(false, fn.IsRelativePath());
}

BOOST_AUTO_TEST_CASE( is_relative_path_with_root_slash )
{
	CFileName fn(L"\\test\\test2\\test3\\test4.txt");
	
	BOOST_REQUIRE_EQUAL(false, fn.IsRelativePath());
}

BOOST_AUTO_TEST_CASE( is_relative_path_sub_path )
{
	CFileName fn(L"test3\\test4.txt");
	
	BOOST_REQUIRE_EQUAL(true, fn.IsRelativePath());
}

BOOST_AUTO_TEST_CASE( is_relative_path_file_only )
{
	CFileName fn(L"test4.txt");
	
	BOOST_REQUIRE_EQUAL(true, fn.IsRelativePath());
}

BOOST_AUTO_TEST_CASE( get_file_name )
{
	CFileName fn(L"c:\\test4.txt");
	
	BOOST_REQUIRE_EQUAL(L"test4.txt", fn.GetFileName().c_str());
}

BOOST_AUTO_TEST_CASE( get_file_name_noext )
{
	CFileName fn(L"c:\\test.txt");
	
	BOOST_REQUIRE_EQUAL(L"test", fn.GetFileName_NoExt().c_str());
}

BOOST_AUTO_TEST_CASE( get_extension )
{
	CFileName fn(L"c:\\test.txt");
	
	BOOST_REQUIRE_EQUAL(L".txt", fn.GetExtension().c_str());
}

BOOST_AUTO_TEST_CASE( get_path )
{
	CFileName fn(L"c:\\test4.txt");
	
	BOOST_REQUIRE_EQUAL(L"c:\\", fn.GetPath().c_str());
}

BOOST_AUTO_TEST_CASE( get_path_nested )
{
	CFileName fn(L"c:\\test3\\test4.txt");
	
	BOOST_REQUIRE_EQUAL(L"c:\\test3\\", fn.GetPath().c_str());
}

BOOST_AUTO_TEST_CASE( root )
{
	CFileName fn(L"test4.txt");
	
	fn.Root(L"c:\\test3\\");
	BOOST_REQUIRE_EQUAL(L"c:\\test3\\test4.txt", fn.c_str());
}

BOOST_AUTO_TEST_CASE( root_no_trailing_slash )
{
	CFileName fn(L"test4.txt");
	
	fn.Root(L"c:\\test3");
	BOOST_REQUIRE_EQUAL(L"c:\\test3\\test4.txt", fn.c_str());
}

BOOST_AUTO_TEST_SUITE_END();